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
        .AppendLine("using static Spv.Specification;")
        .AppendLine("namespace Spv.Generator {")
        .AppendLine("public partial class Module{");

        List<string> classes = new(){
            "Miscellaneous",
            "Debug",
            "Annotation",
            "Type",
            "Constant",
            "Memory",
            "Function",
            "Image",
            "Conversion",
            "Composite",
            "Arithmetic",
            "Bit",
            "Relational_and_Logical",
            "Derivative",
            "Control",
            "Atomic",
            "Primitive",
            "Barrier",
            "Group",
            "Device",
            "Pipe",
            "Non",
            "Reserved",
        };
        classes.ForEach(x =>MethodInfo.GenerateMethodsByClass(generated, spirvCore,x));

        var compil = context.Compilation;
        context.AddSource("Module.Generated.cs", generated.AppendLine("}\n}").ToString());
        
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        
    }

}
