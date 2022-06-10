namespace SpvSourceGenerator;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;


[Generator]
public class ModuleGenerator : ISourceGenerator
{
    public string pathJson = @"..\SPIRV-Headers\include\spirv\unified1\spirv.core.grammar.json";
    public void Execute(GeneratorExecutionContext context)
    {
        Debug.WriteLine("Initalize code generator");
        var compil = context.Compilation;


        var assembly = typeof(ModuleGenerator).GetTypeInfo().Assembly;
        string resourceCoreName = 
            assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("spirv.core.grammar.json"));
            
        string resourceGlslName = 
            assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("extinst.glsl.std.450.grammar.json"));
            
        var spirvCore = JsonDocument.Parse(new StreamReader(assembly.GetManifestResourceStream(resourceCoreName)).ReadToEnd());
        var spirvGlsl = JsonDocument.Parse(new StreamReader(assembly.GetManifestResourceStream(resourceGlslName)).ReadToEnd());
        
        
        var generated = new CodeBuilder()
        .AppendLine("using static Spv.Specification;")
        .AppendLine("namespace Spv.Generator")
        .AppendLine("{")
        .Indent()
        .AppendLineWithIndent("public partial class Module")
        .AppendLineWithIndent("{")
        .Indent();

        
        var glslExtInfo = JsonDocument.Parse("{ \"name\": \"GLSL.std.450\", \"function_prefix\": \"Glsl\"}");
        var oclExtInfo = JsonDocument.Parse("{ \"name\": \"OpenCL.std\", \"function_prefix\": \"OpenCl\"}");

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
        context.AddSource("Module.Generated.cs", generated.ToString());

        #if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
        #endif
        var glslExt = new CodeBuilder()
        .AppendLine("using static Spv.Specification;")
        .AppendLine("namespace Spv.Generator")
        .AppendLine("{")
        .Indent()
        .AppendLineWithIndent("public partial class Module")
        .AppendLineWithIndent("{")
        .Indent();
        MethodInfo.GenerateMethodsForExtinst(glslExt, spirvGlsl, glslExtInfo);
        glslExt
        .AppendLineWithIndent("}")
        .Dedent()
        .AppendLineWithIndent("}");
        context.AddSource("Module.Generated.GlslEXT.cs", glslExt.ToString());        
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        
    }

}
