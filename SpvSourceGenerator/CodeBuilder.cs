using System.Text;

namespace SpvSourceGenerator;

public class CodeBuilder
{
    StringBuilder code = new();
    int indent = 0;
    string indentation => new string(' ',indent * 4);

    public CodeBuilder Indent()
    {
        indent += 1;
        return this;
    }
    public CodeBuilder Dedent()
    {
        indent -= 1;
        return this;
    }

    public CodeBuilder Append(object value)
    {
        code.Append(value.ToString());
        return this;
    }
    public CodeBuilder AppendLine(object value)
    {
        code.AppendLine(value.ToString());
        return this;
    }
    public CodeBuilder AppendWithIndent(object value)
    {
        code.Append(indentation).Append(value.ToString());
        return this;
    }
    public CodeBuilder AppendLineWithIndent(object value)
    {
        code.Append(indentation).AppendLine(value.ToString());
        return this;
    }
    public CodeBuilder AppendLine()
    {
        code.AppendLine();
        return this;
    }
    public override string ToString()
    {
        return code.ToString();
    }
}