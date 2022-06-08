namespace SpvSourceGenerator;
using Microsoft.CodeAnalysis;
using System.Text;

[Generator]
public class ModuleGenerator : ISourceGenerator
{
    public string pathJson = @"..\SPIRV-Headers\include\spirv\unified1\spirv.core.grammar.json";
    public void Execute(GeneratorExecutionContext context)
    {
        var compil = context.Compilation;
        context.AddSource("Module.Generated.cs",
        new StringBuilder().AppendLine("public partial class Module{")
        .AppendLine("public string PathOfJson = \"{pathJson}\";}").ToString());
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        
    }
}
