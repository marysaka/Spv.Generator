namespace SpvSourceGenerator;
using Microsoft.CodeAnalysis;
using System.Reflection;
using System.Text;
using System.Text.Json;


[Generator]
public class ModuleGenerator : ISourceGenerator
{
    public string pathJson = @"..\SPIRV-Headers\include\spirv\unified1\spirv.core.grammar.json";
    public void Execute(GeneratorExecutionContext context)
    {
        var assembly = typeof(ModuleGenerator).GetTypeInfo().Assembly;
        string resourceName = 
            assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("spirv.core.grammar.json"));
        var spirvCoreRes = assembly.GetManifestResourceStream(resourceName);
        string spirvCoreStr = new StreamReader(spirvCoreRes).ReadToEnd();
        var spirvCore = JsonDocument.Parse(spirvCoreStr);
        
        var generated = new StringBuilder()
        .AppendLine("namespace Spv.Generator {")
        .AppendLine("public partial class Module{")
        .Append(new string(' ', 4))
        .AppendLine("public string Name = \""+ spirvCore + "\";}}");

        GenerateMethodsByClass(generated, spirvCore,"Miscellaneous");

        var compil = context.Compilation;
        context.AddSource("Module.Generated.cs", generated.ToString());
        
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        
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
    public static void GenerateMethodForInstruction(StringBuilder code, JsonElement e, JsonDocument extInstructionInfo)
    {
        
    }
}
