using System.Linq;
using System.Text;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp
{
    public class CSharpClassFileModel : ClassFileModel
    {
        public CSharpClassFileModel(string indent = "\t", string newLine = "\n")
        {
            Indent = indent;
            NewLine = newLine;
            FileExt = "cs";
        }

        public override StringBuilder Generate()
        {
            StringBuilder builder = new();
            var currentIndent = 0;

            int importCount = Imports.Count,
                attributeCount = ClassAttributes.Count,
                dataCount = FieldsAndProperties.Count,
                constructorCount = Constructors.Count,
                methodCount = Methods.Count;

            var allEmpty = dataCount < 1 && constructorCount < 1 && methodCount < 1;

            if (importCount > 0)
            {
                Imports.ForEach(import =>
                {
                    builder.Append($"using {import};{NewLine}");
                });
                builder.Append(NewLine);
            }

            if (!string.IsNullOrWhiteSpace(Namespace))
            {
                builder.Append($"namespace {Namespace}{NewLine}{{{NewLine}");
                currentIndent++;
            }

            if (attributeCount > 0)
            {
                IndentStringBuilder(builder, currentIndent);
                builder.Append($"[{string.Join(", ", ClassAttributes)}]{NewLine}");
            }

            IndentStringBuilder(builder, currentIndent);
            builder.Append($"{ClassAccess} class {FileName}");

            if (Relations.Any(r=>r.RelationType == ClassRelationType.Inheritance))
            {
                builder.Append(" :");
            }

            if (Relations.Any(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Class))
            {
                builder.Append(
                    $" {Relations.First(r=>r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Class).Target.Name}");
            }

            if (Relations.Any(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Interface))
            {
                builder.Append(" " + string.Join(", ", Relations.Where(r => r.RelationType == ClassRelationType.Inheritance && r.Target.Type == FileType.Interface).Select(x=>x.Target.Name)));
            }

            IndentStringBuilder(builder.Append(NewLine), currentIndent++);
            builder.Append($"{{{NewLine}");

            FieldsAndProperties.ForEach(d =>
            {
                IndentStringBuilder(builder, currentIndent);

            });

            Constructors.ForEach(ctr =>
            {
                IndentStringBuilder(builder, currentIndent);

                builder.Append($"{Helper.ToString(ctr.Access)} {ctr.NameType.Name}({string.Join(", ",ctr.Params.Select(p => $"{p.Type} {p.Name}"))}){{{NewLine}");
                IndentStringBuilder(builder, ++currentIndent);
                builder.Append($"{NewLine}");
                IndentStringBuilder(builder, --currentIndent);
                builder.Append($"}}{NewLine}");
            });
            Methods.ForEach(m =>
            {
                IndentStringBuilder(builder, currentIndent);

                builder.Append($"{Helper.ToString(m.Access)} ");
                if (m.NameType.IsStatic)
                {
                    builder.Append(m.NameType.IsStatic ? "static " : "");
                }
                builder.Append($"{m.NameType.Type} {m.NameType.Name}({string.Join(", ", m.Params.Select(p => $"{p.Type} {p.Name}"))}){NewLine}");

                IndentStringBuilder(builder, currentIndent);
                builder.Append($"{{{NewLine}");
                IndentStringBuilder(builder, ++currentIndent);
                builder.Append($"{NewLine}");
                IndentStringBuilder(builder, --currentIndent);
                builder.Append($"}}{NewLine}");
            });

            if (allEmpty)
            {
                IndentStringBuilder(builder, currentIndent);
                builder.Append(NewLine);
            }
            IndentStringBuilder(builder, --currentIndent);
            builder.Append($"}}{(string.IsNullOrWhiteSpace(Namespace) ? "" : NewLine)}");

            if (string.IsNullOrWhiteSpace(Namespace)) return builder;
            builder.Append('}');
            currentIndent--;

            return builder;
        }
    }
}