using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedCodeGeneration.DataLayer.Files
{
    internal sealed class CSharpFileModel : FileModel
    {
        public string Namespace { get; set; }

        public List<string> ClassAttributes { get; set; } = new();
        public string ClassAccess { get; set; }
        public string ClassName { get; set; }
        
        public List<string> FieldsAndProperties { get; set; } = new();
        public List<string> Constructors { get; set; } = new();


        public CSharpFileModel(string indent = "\t", string newLine = "\n")
        {
            Indent = indent;
            NewLine = newLine;
        }

        public override string ToString()
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

            ClassAttributes.ForEach(attr =>
            {
                IndentStringBuilder(builder, currentIndent);

                builder.Append($"{attr}{NewLine}");
            });

            IndentStringBuilder(builder, currentIndent);
            builder.Append($"{ClassAccess} class {ClassName}{NewLine}");
            IndentStringBuilder(builder, currentIndent++);
            builder.Append($"{{{NewLine}");

            IndentStringBuilder(builder, currentIndent);

            Constructors.ForEach(ctr =>
            {
                IndentStringBuilder(builder, currentIndent);

                builder.Append($"{ctr}{NewLine}");
            });

            builder.Append(NewLine);
            IndentStringBuilder(builder, --currentIndent);
            builder.Append($"}}{(string.IsNullOrWhiteSpace(Namespace) ? "" : NewLine)}");

            if (string.IsNullOrWhiteSpace(Namespace)) return builder.ToString();
            builder.Append('}');
            currentIndent--;

            return builder.ToString();
        }
    }
}