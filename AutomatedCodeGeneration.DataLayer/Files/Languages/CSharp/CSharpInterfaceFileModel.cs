using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp
{
    internal class CSharpInterfaceFileModel : InterfaceFileModel
    {
        public CSharpInterfaceFileModel(string indent = "\t", string newLine = "\n")
        {
            Indent = indent;
            NewLine = newLine;
            FileExt = "cs";
        }

        public override StringBuilder Generate()
        {
            StringBuilder builder = new();
            var currentIndent = 0;

            if (Imports.Count > 0)
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

                builder.Append($"{Helper.ToString(m.Access)} {m.NameType.Type} {m.NameType.Name}({string.Join(", ", m.Params.Select(p => $"{p.Type} {p.Name}"))}){NewLine};");
            });

            IndentStringBuilder(builder, currentIndent);
            builder.Append(NewLine);
            IndentStringBuilder(builder, --currentIndent);
            builder.Append($"}}{(string.IsNullOrWhiteSpace(Namespace) ? "" : NewLine)}");

            return string.IsNullOrWhiteSpace(Namespace) ? builder : builder.Append('}');
        }
    }
}