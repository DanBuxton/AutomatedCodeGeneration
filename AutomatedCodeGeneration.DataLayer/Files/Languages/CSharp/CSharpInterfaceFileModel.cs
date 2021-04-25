using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp
{
    internal class CSharpInterfaceFileModel : InterfaceFileModel//, ICSharpFile
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

            //FieldsAndProperties.Where(d=>d.Access == Enums.AccessType.Private).ToList().ForEach(f =>
            //{
            //    IndentStringBuilder(builder, currentIndent);

            //    if (f.NameType.IsStatic)
            //    {
            //        builder.Append($"private static {f.NameType.Type} {f.NameType.Name.ToUpper()};");
            //    }
            //    else
            //    {
            //        builder.Append($"private {f.NameType.Type} _{f.NameType.Name[0].ToString().ToLower()}{f.NameType.Name[1..]};");
            //    }
            //});

            //FieldsAndProperties.ForEach(d =>
            //{
            //    var removed = new List<ClassMethodModel>();

            //    foreach (var m in Methods)
            //    {
            //        Debug.WriteLine(m.NameType.Name[2..]);

            //        if (!m.NameType.Name[2..].Equals(d.NameType.Name)) continue;

            //        if (!removed.Contains(m))
            //        {
            //            removed.Add(m);
            //        }

            //        Methods.Remove(m);
            //    }
            //});

            Methods.ForEach(m =>
            {
                IndentStringBuilder(builder, currentIndent);

                builder.Append($"{Helper.ToString(m.Access)} {m.NameType.Type} {m.NameType.Name}({string.Join(", ", m.Params.Select(p => $"{p.Type} {p.Name}"))}){NewLine};");
            });

            IndentStringBuilder(builder, currentIndent);
            builder.Append(NewLine);
            IndentStringBuilder(builder, --currentIndent);
            builder.Append($"}}{(string.IsNullOrWhiteSpace(Namespace) ? "" : NewLine)}");

            if (string.IsNullOrWhiteSpace(Namespace)) return builder;
            builder.Append('}');
            currentIndent--;

            return builder;
        }
    }
}