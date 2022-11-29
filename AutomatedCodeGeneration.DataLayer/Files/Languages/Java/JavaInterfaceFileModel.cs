using System.Linq;
using System.Text;
// ReSharper disable AccessToModifiedClosure

namespace AutomatedCodeGeneration.DataLayer.Files.Languages.Java;

public class JavaInterfaceFileModel : InterfaceFileModel
{
    public JavaInterfaceFileModel(string indent = "\t", string newLine = "\n")
    {
        Indent = indent;
        NewLine = newLine;
        FileExt = "java";
    }
    //public CSharpClassFileModel(IFileModel model) : this(model.Indent, model.NewLine)
    //{

    //}

    public override StringBuilder Generate()
    {
        StringBuilder builder = new();
        var currentIndent = 0;

        if (!string.IsNullOrWhiteSpace(Namespace))
        {
            builder.Append($"package {Namespace};{NewLine}{NewLine}");
        }

        if (Imports.Count > 0)
        {
            builder.Append("import " + string.Join($";{NewLine}import ", Imports) + $";{NewLine}{NewLine}");
        }

        Attributes.ForEach(attr =>
        {
            IndentStringBuilder(builder, currentIndent);

            builder.Append($"{attr}{NewLine}");
        });

        IndentStringBuilder(builder, currentIndent);
        builder.Append($"{Access} interface {FileName}{NewLine}");
        IndentStringBuilder(builder, currentIndent++);
        builder.Append($"{{{NewLine}");

        Methods.ForEach(m =>
        {
            IndentStringBuilder(builder, currentIndent);

            builder.Append($"{Helper.ToString(m.Access)} {m.NameType.Type} {m.NameType.Name}({string.Join(", ", m.Params.Select(p => $"{p.Type} {p.Name}"))});{NewLine}");
        });

        IndentStringBuilder(builder, currentIndent);
        builder.Append(NewLine);
        IndentStringBuilder(builder, --currentIndent);
        return builder.Append('}');
    }
}