﻿using System.Linq;
using System.Text;

namespace AutomatedCodeGeneration.DataLayer.Files.Languages.Java
{
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

            if (Imports.Count > 0)
            {
                Imports.ForEach(import =>
                {
                    builder.Append($"import {import};{NewLine}");
                });
                builder.Append(NewLine);
            }

            if (!string.IsNullOrWhiteSpace(Namespace))
            {
                builder.Append($"namespace {Namespace}{NewLine}{{{NewLine}");
                currentIndent++;
            }

            ClassAttributes.ForEach(attr =>
            {
                IndentStringBuilder(builder, currentIndent);

                builder.Append($"{attr}{NewLine}");
            });

            IndentStringBuilder(builder, currentIndent);
            builder.Append($"{ClassAccess} class {ClassName}{NewLine}");
            IndentStringBuilder(builder, currentIndent++);
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
            builder.Append($"}}{(string.IsNullOrWhiteSpace(Namespace) ? "" : NewLine)}");

            return string.IsNullOrWhiteSpace(Namespace) ? builder : builder.Append('}');
        }
    }
}