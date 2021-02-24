using System;
using System.IO;

namespace AutomatedCodeGeneration.DataLayer
{
    public sealed record SystemInfo
    {
        public Guid Id { get; init; }
        public string TargetLanguage { get; init; }
        public string Output { get; set; }

        public SystemInfo(Guid id, string lang, string output = null) => (Id, TargetLanguage, Output) = (id, lang, output ?? Directory.GetCurrentDirectory());

        public void Deconstruct(out Guid id, out string lang, out string output) => (id, lang, output) = (Id, TargetLanguage, Output);
    }
}
