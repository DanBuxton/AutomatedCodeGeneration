using System.Text;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Files
{
    public abstract class FileModel : IFileModel
    {
        public string Indent { get; protected set; }
        public string NewLine { get; protected set; }
        public char? LineDelimiter { get; protected set; } = ';';
        public string FileName { get; set; }
        public string FileExt { get; protected set; }

        public void IndentStringBuilder(StringBuilder value, int noOfTimes)
        {
            for (var i = 0; i < noOfTimes; i++)
            {
                value.Append(Indent);
            }
        }

        public abstract StringBuilder Generate();
    }
}
