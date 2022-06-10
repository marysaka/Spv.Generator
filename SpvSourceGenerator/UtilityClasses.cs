using System.Text;
using System.Text.Json;
using System;

namespace SpvSourceGenerator;


public class MethodArgument
{


    public string Name { get; set; }
    public string RealType { get; set; }
    public string CSType { get; set; }
    public bool Optional { get; set; }
    public bool Variable { get; set; }
    public MethodArgument? BehindOptionalArgument { get; set; }


    public MethodArgument(string name, string realType, string cSType, bool optional, bool variable, MethodArgument behindOptionalArgument)
    {
        Name = name;
        RealType = realType;
        CSType = cSType;
        Optional = optional;
        Variable = variable;
        BehindOptionalArgument = behindOptionalArgument;
    }
    public MethodArgument(string name, string realType, string cSType, bool optional, bool variable)
    {
        Name = name;
        RealType = realType;
        CSType = cSType;
        Optional = optional;
        Variable = variable;
    }

    private string GetDefaultValue()
    {
        if (CSType == "bool")
            return "false";
        if (CSType != "Instruction" && CSType != "string")
            return $"({CSType})int.MaxValue";
        return "null";
    }

    public string GetPrototypeName()
    {
        if (Optional)
            return $"{CSType} {Name} = {GetDefaultValue()}";
        if (Variable)
            return $"params {CSType}[] {Name}";
        return $"{CSType} {Name}";
    }

    public string AsOperand()
    {
        var enumDefined = new List<string>{
            "FPRoundingMode"
        };
        
        if (enumDefined.Contains(CSType))
            return $"LiteralInteger.CreateForEnum({Name})";
        return Name;
    }

    public void AddOperandOperation(CodeBuilder code)
    {
        if (Name == "resultType" || Name == "forceIdAllocation")
            return;

        MethodArgument? optionalCheck = null;
        if (Optional)
            optionalCheck = this;
        else if (BehindOptionalArgument is not null)
            optionalCheck = BehindOptionalArgument;

        if (optionalCheck is not null)
        {
            code.AppendLineWithIndent($"if({optionalCheck.Name} != {optionalCheck.GetDefaultValue()})");
            code.AppendLineWithIndent("{").Indent();
        }
        code.AppendLineWithIndent($"result.AddOperand({Name});");
        if (optionalCheck is not null)
        {
            code.AppendLineWithIndent("}").Dedent();
        }
    }


}


public class MethodInfo
{

    public string Name { get; set; }
    public JsonDocument ExtinstInfo { get; set; }
    public bool BoundIncrementNeeded { get; set; }
    public int ResultTypeIndex { get; set; }
    public string OpCode { get; set; }
    public List<MethodArgument> Arguments { get; set; }

    public string CL { get; set; }

    public MethodInfo(JsonElement instruction, JsonDocument extinst_info)
    {
        this.ExtinstInfo = extinst_info;
        this.BoundIncrementNeeded = false;
        this.ResultTypeIndex = -1;
        this.OpCode = instruction.GetProperty("opcode").GetInt32().ToString();
        this.Arguments = new List<MethodArgument>();

        if (ExtinstInfo != null)
        {
            CL = "ExtInst";
            Name = extinst_info.RootElement.GetProperty("function_prefix") + instruction.GetProperty("opname").GetString();
            Arguments.Add(new MethodArgument("resultType", "IdRef", "Instruction", false, false));
        }
        else
        {
            Name = instruction.GetProperty("opname").GetString();
            CL = instruction.GetProperty("class").GetString();
        }
        var i = 0;

        if (instruction.TryGetProperty("operands", out JsonElement operands))
        {
            foreach (var operand in operands.EnumerateArray())
            {
                var op = operand;
                if (operand.GetProperty("kind").GetString() != "IdResult")
                {
                    if (op.GetProperty("kind").GetString() == "IdResultType")
                        ResultTypeIndex = i;

                    var variable = op.TryGetProperty("quantifier", out _) && op.GetProperty("quantifier").GetString() == "*";
                    var optional = operand.TryGetProperty("quantifier", out _) && op.GetProperty("quantifier").GetString() == "?";

                    // The core grammar doesn't contains the optional <id> when ImageOperands is defined on image instructions, add them manually.
                    if (operand.GetProperty("kind").GetString() == "ImageOperands" && CL == "Image")
                    {
                        var image_operands = new MethodArgument(GetArgumentName(operand, i), operand.GetProperty("kind").GetString(), GetTypeByOperand(operand), false, false);

                        if (optional)
                        {
                            // TODO: improve this as this generate two if..
                            image_operands.BehindOptionalArgument = image_operands;
                        }

                        Arguments.Add(image_operands);
                        Arguments.Add(new MethodArgument("imageOperandIds", "IdRef", "Instruction", false, true, image_operands));
                    }
                    else
                        Arguments.Add(new MethodArgument(GetArgumentName(op, i), op.GetProperty("kind").GetString(), GetTypeByOperand(op), optional, variable));

                    //Decoration and ExecutionMode are special as they carry variable operands
                    if (new string[] { "Decoration", "ExecutionMode" }.Contains(operand.GetProperty("kind").GetString()))
                        Arguments.Add(new MethodArgument("parameters", "Operands", "Operand", false, true));

                    i += 1;
                }
                else
                    BoundIncrementNeeded = true;
            }
        }
        if (CL == "Type-Declaration")
        {
            var force_id_allocation_arg = new MethodArgument("forceIdAllocation", "bool", "bool", !new string[] { "TypeFunction", "TypeStruct" }.Contains(Name), false);
            if (new string[] { "TypeFunction", "TypeStruct" }.Contains(Name))
                Arguments.Insert(Arguments.Count - 1, force_id_allocation_arg);
            else
                Arguments.Add(force_id_allocation_arg);
        }
        foreach (var argument in Arguments)
            FixPossibleArgumentConflicts(argument.Name);
    }
    void FixPossibleArgumentConflicts(string name)
    {
        int conflictCount = -1;

        foreach (var argument in Arguments)
            if (argument.Name == name)
                conflictCount += 1;

        if (conflictCount > 0)
        {
            int index = 0;
            foreach (var argument in Arguments)
            {
                if (argument.Name == name)
                {
                    argument.Name = $"{argument.Name}{index}";
                    index += 1;
                }
            }
        }
    }
    
    static string[] blacklist = {
        "OpExtInstImport",
        "OpExtension",
        };
    public static void GenerateMethodsByClass(CodeBuilder code, JsonDocument spec, string className)
    {
        code.AppendWithIndent("// ").AppendLine(className);
        foreach(var instruction in GetInstructionByClass(spec,className))
        {
            var opname = instruction.GetProperty("opname").GetString();
            if(blacklist.Contains(opname))
                continue;
            GenerateMethodForInstruction(code, instruction);
        }
    }

    public static void GenerateMethodsForExtinst(CodeBuilder code, JsonDocument spec, JsonDocument extinstInfo)
    {
        foreach(var instruction in spec.RootElement.GetProperty("instructions").EnumerateArray())
            GenerateMethodForInstruction(code, instruction, extinstInfo);
    }
    public static List<JsonElement> GetInstructionByClass(JsonDocument spec, string className)
    {
        var result = new List<JsonElement>();
        foreach( var instruction in spec.RootElement.GetProperty("instructions").EnumerateArray())
        {
            if(instruction.GetProperty("class").GetString() == className)
                result.Add(instruction);
        }
        return result;
    }

    public static void GenerateMethodForInstruction(CodeBuilder code, JsonElement instruction)
    {
        var mi = new MethodInfo(instruction, null);
        if(mi.Name == "OpenClPrintf")
            return;
        GenerateMethodPrototype(code, mi);
        GenerateMethodDefinition(code, mi);
    }

    public static void GenerateMethodForInstruction(CodeBuilder code, JsonElement instruction, JsonDocument extInstructionInfo)
    {
        var mi = new MethodInfo(instruction, extInstructionInfo);
        if(mi.Name == "OpenClPrintf")
            return;
        GenerateMethodPrototype(code, mi);
        GenerateMethodDefinition(code, mi);
    }

    public static void GenerateMethodPrototype(CodeBuilder code, MethodInfo mi)
    {
        var name = mi.Name.Contains("Glsl") ? mi.Name.Replace("GlslOp", "Glsl") : mi.Name[2..];
        code.AppendWithIndent($"public Instruction {name}(");
        var arguments = new List<string>();
        arguments = 
            mi.Arguments
            .Where(x => !x.GetPrototypeName().Contains("params"))
            .Select(x => x.GetPrototypeName())
            .ToList();

        if(mi.Arguments.Any(x => x.GetPrototypeName().Contains("params")))
            arguments.Add(
                mi.Arguments.First(x => x.GetPrototypeName().Contains("params")).GetPrototypeName()
            );
        
        
        
        code.Append(string.Join(", ", arguments));
        code.AppendLine(")");

    }

    private static void GenerateMethodDefinition(CodeBuilder code, MethodInfo mi)
    {
        code.AppendLineWithIndent("{").Indent();
        if(mi.ExtinstInfo is not null)
        {
            var arguments = new List<string>();
            foreach(var arg in mi.Arguments.GetRange(1, mi.Arguments.Count -1))
            {
                arguments.Add(arg.AsOperand());
            }
            code.AppendLineWithIndent(
                $"return ExtInst(resultType, AddExtInstImport(\"{mi.ExtinstInfo.RootElement.GetProperty("name")}\"), {mi.OpCode}, {string.Join(", ", arguments)});"
            );
        }
        else if(mi.BoundIncrementNeeded)
        {
            if(mi.ResultTypeIndex != -1)
            {
                var argument = mi.Arguments[mi.ResultTypeIndex];
                if(mi.CL== "Constant-Creation" && mi.Name.StartsWith("Constant"))
                    code.AppendLineWithIndent($"Instruction result = new Instruction(Op.{mi.Name}, Instruction.InvalidId, {argument.Name});");
                else
                    code.AppendLineWithIndent($"Instruction result = new Instruction(Op.{mi.Name}, GetNewId(), {argument.Name});");
            }
            else
            {
                if(mi.CL == "Type-Declaration" || mi.Name == "Label")
                    code.AppendLineWithIndent($"Instruction result = new Instruction(Op.{mi.Name});");
                else
                    code.AppendLineWithIndent($"Instruction result = new Instruction(Op.{mi.Name}, GetNewId());");
            }
        }
        else
        {
            if(mi.ResultTypeIndex != -1)
                throw new NotImplementedException();
            code.AppendLineWithIndent($"Instruction result = new Instruction(Op.{mi.Name});");
        }
        if(mi.ExtinstInfo is null)
        {
            code.AppendLine();
            foreach(var arg in mi.Arguments)
                arg.AddOperandOperation(code);
            
            if(mi.CL.Contains("Type-Declaration"))
                code.AppendLineWithIndent("AddTypeDeclaration(result, forceIdAllocation);").AppendLine();
            else if(mi.CL.Contains("Debug"))
                code.AppendLineWithIndent("AddDebug(result);").AppendLine();
            else if(mi.CL.Contains("Annotation"))
                code.AppendLineWithIndent("AddAnnotation(result);").AppendLine();
            else if(mi.CL.Contains("Constant-Creation") && mi.Name.StartsWith("Constant"))
                code.AppendLineWithIndent("AddConstant(result);").AppendLine();
            else if(!mi.Name.Contains("Variable") && !mi.Name.Contains("Label"))
                code.AppendLineWithIndent("AddToFunctionDefinitions(result);").AppendLine();

            code.AppendLineWithIndent("return result;");

        }
        code
        .Dedent()
        .AppendLineWithIndent("}");
    }

    
    public static string GetArgumentName(JsonElement operand, int position)
    {
        if(operand.GetProperty("kind").GetString() == "IdResultType")
            return "resultType";
        if(operand.TryGetProperty("name", out var nameProp) && !nameProp.GetString().Any(x => x == '\n' || x == '~' || x == ','))
        {
            var name = nameProp.GetString().Replace("'","").Replace(" ", "").Replace(".","");
            name = char.ToLower(name[0]) + name[1 .. name.Length];
            return name switch
            {
                "object" => "obj",
                "string" => "str",
                "base" => "baseObj",
                "default" => "defaultObj",
                "event" => "eventObj",
                "result" => "resultObj",
                _ => name
            };
            
        }
        string[] namemapping = {
            "Dim",
            "ImageFormat",
            "AccessQualifier",
            "AccessQualifier",
            "StorageClass",
            "SamplerAddressingMode",
            "SamplerFilterMode",
            "FunctionControl",
            "ImageOperands",
            "LoopControl",
            "SelectionControl",
            "MemoryAccess",
            "Decoration",
            "SourceLanguage"
        };

        if(namemapping.Contains(operand.GetProperty("kind").GetString()))
        {
            var x = operand.GetProperty("kind").GetString();
            return string.Concat(x.Substring(0,1).ToLower(), x.AsSpan(1,x.Length-1));
        }
        if(operand.TryGetProperty("name", out var nameProp2) && nameProp2.GetString() == "\'D~ref~\'")
            return "parameters";

        Console.WriteLine($"// Unmanaged argument name: {operand}");
        return $"arg{position}";
    }
    public static string GetTypeByOperand(JsonElement operand)
    {
        string[] enumMasks = {
            "MemoryAccess", 
            "ImageOperands", 
            "LoopControl", 
            "SelectionControl", 
            "FunctionControl"
        };
        Dictionary<string,string> typeMapping = 
            new (){
                {"LiteralString", "string"},
                {"IdRef", "Instruction"},
                {"IdResultType", "Instruction"},
                {"IdScope", "Instruction"},
                {"IdMemorySemantics", "Instruction"},
                {"PairIdRefIdRef", "Instruction"},
                {"LiteralContextDependentNumber", "LiteralInteger"},
                {"LiteralSpecConstantOpInteger", "LiteralInteger"},
                {"PairLiteralIntegerIdRef", "Operand"},
                {"PairIdRefLiteralInteger", "Operand"},
                {"LiteralExtInstInteger", "LiteralInteger"},
            };

        var kind = operand.GetProperty("kind").GetString();
        string result = kind;
        if(typeMapping.TryGetValue(kind, out var r))
            result = r;
        else if(enumMasks.Contains(kind))
            result = kind + "Mask";
        return result;
    }
}
