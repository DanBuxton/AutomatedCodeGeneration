using System;
using AutomatedCodeGeneration.DataLayer;

namespace AutomatedCodeGeneration.Models
{
    public static class Helper
    {
        public static Enums.Languages? LanguageExists(string lang) => DataLayer.Helper.GetLanguage(lang);

        public static SystemInfo CreateSystemInfo(Guid id, string language, string output) => new(id, language, output);
    }
}
