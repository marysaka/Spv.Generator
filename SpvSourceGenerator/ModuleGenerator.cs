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
        
        var generated = new CodeBuilder()
        .AppendLine("using static Spv.Specification;")
        .AppendLine("namespace Spv.Generator")
        .AppendLine("{")
        .Indent()
        .AppendLineWithIndent("public partial class Module")
        .AppendLineWithIndent("{")
        .Indent();

        List<string> classes = new(){
            "Miscellaneous",
            "Debug",
            "Annotation",
            "Type-Declaration",
            "Constant-Creation",
            "Memory",
            "Function",
            "Image",
            "Conversion",
            "Composite",
            "Arithmetic",
            "Bit",
            "Relational_and_Logical",
            "Derivative",
            "Control-Flow",
            "Atomic",
            "Primitive",
            "Barrier",
            "Group",
            "Device-Side_Enqueue",
            "Pipe",
            "Non-Uniform",
            "Reserved",
        };
        classes.ForEach(x =>MethodInfo.GenerateMethodsByClass(generated, spirvCore,x));
        generated
        .AppendLineWithIndent("}")
        .Dedent()
        .AppendLineWithIndent("}");
        var compil = context.Compilation;
        context.AddSource("Module.Generated.cs", generated.ToString());
        
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        
    }

}
