using System.Collections.Generic;
using System.Text;
using AutomatedCodeGeneration.DataLayer.Files.Languages;

namespace AutomatedCodeGeneration.DataLayer.Files.Abstractions;

public interface IFileModel : ILanguageFile
{
    string Indent { get; }
    string NewLine { get; }
    char? LineDelimiter { get; }
    string FileName { get; }
    string FileExt { get; }

    void IndentStringBuilder(StringBuilder value, int noOfTimes);
}