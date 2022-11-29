using System;
using System.IO;

namespace AutomatedCodeGeneration.DataLayer;

public sealed record SystemInfo
{
    public Guid Id { get; }
    public string TargetLanguage { get; }
    public string Output { get; }

    public SystemInfo(Guid id, string lang, string output = null)
    {
        Id = id;
        TargetLanguage = lang;

        if (Directory.Exists(output) || output != null && output[..8].Equals("github::"))
        {
            Output = output;
        }
        else
        {
            Output = Directory.GetCurrentDirectory();
        }

        //if (output is null)
        //{
        //    Output = Directory.GetCurrentDirectory();
        //}
        //else// if (Directory.Exists(output) || output[..8].Equals("github::"))
        //{
        //    Output = output;
        //}
    }

    public void Deconstruct(out Guid id, out string lang, out string output) => (id, lang, output) = (Id, TargetLanguage, Output);
}
