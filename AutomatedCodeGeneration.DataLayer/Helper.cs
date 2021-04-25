using System;
using static AutomatedCodeGeneration.DataLayer.Enums;

namespace AutomatedCodeGeneration.DataLayer
{
    public static class Helper
    {
        public static Languages? GetLanguage(string lang) => Enum.TryParse(lang, true, out Languages l) ? l : null;

        public static string AsLowerString<T>(this T val) =>
            val.ToString()?.ToLower().Replace('_', ' ');

        public static string ToString(AccessType access) =>
            access switch
            {
                AccessType.Internal or AccessType.Private or AccessType.Protected or AccessType.Public => access.ToString().ToLower(),
                AccessType.Protected_Internal => "protected internal",
                _ => throw new NotSupportedException()
            };
    }
}
