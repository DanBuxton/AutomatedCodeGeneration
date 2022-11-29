using System.Linq;
using System.Text;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Languages.Java;

public class JavaClassFileModel : ClassFileModel
{
    public JavaClassFileModel(string indent = "\t", string newLine = "\n")
    {
        Indent = indent;
        NewLine = newLine;
        FileExt = "java";
    }
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
            builder.Append("import " + string.Join($";{NewLine}import ", Imports.Where(i => !i.Equals(Namespace))) + $";{NewLine}{NewLine}");
        }

        ClassAttributes.ForEach(attr =>
        {
            IndentStringBuilder(builder, currentIndent);

            builder.Append($"{attr}{NewLine}");
        });

        IndentStringBuilder(builder, currentIndent);
        builder.Append($"{ClassAccess} class {FileName}");

        if (Relations.Any(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Class))
        {
            builder.Append(
                $" extends {Relations.First(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Class).Target.Name}");
        }

        if (Relations.Any(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Interface))
        {
            builder.Append(" implements " + string.Join(", ", Relations.Where(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Interface).Select(x=>x.Target.Name)));
        }

        IndentStringBuilder(builder.Append(NewLine), currentIndent++);
        builder.Append($"{{{NewLine}");

        FieldsAndProperties.ForEach(d =>
        {

        });

        Constructors.ForEach(ctr =>
        {
            IndentStringBuilder(builder, currentIndent);

            builder.Append($"{Helper.ToString(ctr.Access)} {ctr.NameType.Name}({string.Join(", ", ctr.Params.Select(p => $"{p.Type} {p.Name}"))}){{{NewLine}");
            IndentStringBuilder(builder, ++currentIndent);
            builder.Append($"{NewLine}");
            IndentStringBuilder(builder, --currentIndent);
            builder.Append($"}}{NewLine}");
        });
        Methods.ForEach(m =>
        {
            IndentStringBuilder(builder, currentIndent);

            builder.Append($"{Helper.ToString(m.Access)} {m.NameType.Type} {m.NameType.Name}({string.Join(", ", m.Params.Select(p => $"{p.Type} {p.Name}"))}){NewLine}");
            IndentStringBuilder(builder, currentIndent);
            builder.Append($"{{{NewLine}");
            IndentStringBuilder(builder, ++currentIndent);
            builder.Append($"{NewLine}");
            IndentStringBuilder(builder, --currentIndent);
            builder.Append($"}}{NewLine}");
        });

        //builder.Append(NewLine);
        IndentStringBuilder(builder, currentIndent);
        builder.Append(NewLine);
        IndentStringBuilder(builder, --currentIndent);
        return builder.Append('}');
    }
}