using System.Collections.Generic;
using System.Text;

namespace AutomatedCodeGeneration.DataLayer.Files
{
    public class FileModel
    {
        public string Indent { get; protected set; }
        public string NewLine { get; protected set; }
        public char? LineDelimiter { get; protected set; } = ';';

        public List<string> Imports { get; protected internal set; } = new();

        public string ClassName { get; set; }

        protected void IndentStringBuilder(StringBuilder builder, int n)
        {
            for (var i = 0; i < n; i++)
            {
                builder.Append(Indent);
            }
        }
    }
}
