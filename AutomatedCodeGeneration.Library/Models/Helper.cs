using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutomatedCodeGeneration.Library.Models
{
    public static class Helper
    {
        public static Enums.Languages? LanguageExists(string lang) => Enum.TryParse(lang, true, out Enums.Languages l) ? l : null;

        public static SystemInfo CreateSystemInfo(Guid id, string language) => new (id, language);
    }
}
