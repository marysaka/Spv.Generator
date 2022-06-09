using System.Text;
using System.Text.Json;

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

    public void AddOperandOperation(StringBuilder code)
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
            code.AppendLine($"if({optionalCheck.Name} != {optionalCheck.GetDefaultValue()})");
            code.AppendLine("{");
        }
        code.AppendLine($"result.AddOperand({Name})");
        if (optionalCheck is not null)
        {
            code.AppendLine("}");
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

        if (instruction.TryGetProperty("operand", out JsonElement operands))
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
                        Arguments.Add(new MethodArgument(GetArgumentName(operand, i), operand.GetProperty("kind").GetString(), GetTypeByOperand(operand), optional, variable));

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
    public static void GenerateMethodsByClass(StringBuilder code, JsonDocument spec, string className)
    {
        code.Append(new string(' ', 4));
        code.Append("// ").AppendLine(className);
        foreach(var instruction in GetInstructionByClass(spec,className))
        {
            var opname = instruction.GetProperty("opname").GetString();
            if(blacklist.Contains(opname))
                continue;
            GenerateMethodForInstruction(code, instruction, null);
        }
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
    public static void GenerateMethodForInstruction(StringBuilder code, JsonElement instruction, JsonDocument extInstructionInfo)
    {
        var mi = new MethodInfo(instruction, extInstructionInfo);
        if(mi.Name == "OpenClPrinf")
            return;
        GenerateMethodPrototype(code, mi);
        GenerateMethodDefinition(code, mi);
    }

    private static void GenerateMethodDefinition(StringBuilder code, MethodInfo mi)
    {
        code.AppendLine("{");
        if(mi.ExtinstInfo is not null)
        {
            var arguments = new List<string>();
            foreach(var arg in mi.Arguments.GetRange(1, mi.Arguments.Count))
            {
                arguments.Add(arg.AsOperand());
            }
            code.AppendLine(
                $"return ExtInst(resultType, AddExtInstImport(\"{mi.ExtinstInfo.RootElement.GetProperty("name")}\"), {mi.OpCode}, {string.Join(", ", arguments)});"
            );
        }
        else if(mi.BoundIncrementNeeded)
        {
            if(mi.ResultTypeIndex != -1)
            {
                var argument = mi.Arguments[mi.ResultTypeIndex];
                if(mi.CL== "Constant-Creation" && mi.Name.StartsWith("Constant"))
                    code.AppendLine($"Instruction result = new Instruction({mi.Name}, Instruction.InvalidId, {argument.Name})");
                else
                    code.AppendLine($"Instruction result = new Instruction({mi.Name}, GetNewId(), {argument.Name})");
            }
            else
            {
                if(mi.CL == "Type-Declaration" || mi.Name == "Label")
                    code.AppendLine($"Instruction result = new Instruction(Op.{mi.Name});");
                else
                    code.AppendLine($"Instruction result = new Instruction(Op.{mi.Name}, GetNewId());");
            }
        }
        else
        {
            if(mi.ResultTypeIndex != -1)
                throw new NotImplementedException();
            code.AppendLine($"Instruction result = new Instruction(Op.{mi.Name});");
        }
        if(mi.ExtinstInfo is null)
        {
            code.AppendLine();
            foreach(var arg in mi.Arguments)
                arg.AddOperandOperation(code);
            
            if(mi.CL == "Type-Declaration")
                code.AppendLine("AddTypeDeclaration(result, forceIdAllocation);").AppendLine();
            else if(mi.CL == "Debug")
                code.AppendLine("AddDebug(result);").AppendLine();
            else if(mi.CL == "Annotation")
                code.AppendLine("AddAnnotation(result);").AppendLine();
            else if(mi.CL == "Constant-Creation" && mi.Name.StartsWith("Constant"))
                code.AppendLine("AddConstant(result);").AppendLine();
            else if(mi.Name != "Variable" && mi.Name != "Label")
                code.AppendLine("AddToFunctionDefinitions(result);").AppendLine();

            code.AppendLine("return result;")
            .AppendLine("}");

        }
    }

    public static void GenerateMethodPrototype(StringBuilder code, MethodInfo mi)
    {
        code.Append($"public Instruction {mi.Name}(");
        var arguments = new List<string>();

        var i = 0;

        foreach(var arg in mi.Arguments)
        {
            arguments.Add(arg.GetPrototypeName());
            i+=1;
        }
        code.Append(string.Join(", ", arguments));
        code.AppendLine(")");

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
            return x.Substring(1).ToLower() + x.Substring(1,x.Length);
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
        string result = string.Empty;
        if(typeMapping.TryGetValue(kind, out var r))
            result = r;
        if(enumMasks.Contains(kind))
            result = kind + "Mask";
        return result;
    }
}
