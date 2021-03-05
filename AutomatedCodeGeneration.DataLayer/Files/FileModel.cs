using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCodeGeneration.DataLayer.Files
{
    public class FileModel
    {
        public string Indent { get; protected set; }
        public string NewLine { get; protected set; }
        public char? LineDelimiter { get; protected set; } = ';';

        public List<string> Imports { get; protected internal set; } = new();
        
        protected void IndentStringBuilder(StringBuilder builder, int n)
        {
            for (var i = 0; i < n; i++)
            {
                builder.Append(Indent);
            }
        }
    }
}
