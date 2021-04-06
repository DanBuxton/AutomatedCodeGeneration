using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutomatedCodeGeneration.DataLayer
{
    public static class Helper
    {
        public static Enums.Languages? GetLanguage(string lang) => Enum.TryParse(lang, true, out Enums.Languages l) ? l : null;

        public static string ToString(AccessType access) =>
            access switch
            {
                AccessType.Internal or AccessType.Private or AccessType.Protected or AccessType.Public => access.ToString().ToLower(),
                AccessType.ProtectedInternal => "protected internal",
                _ => throw new ArgumentOutOfRangeException()
            };

        private static IEnumerable<Type> GetTypes(string ns) =>
            typeof(Helper).GetTypeInfo().Assembly.GetTypes()
            .Where(t => string.Equals(t.Namespace, ns, StringComparison.Ordinal));
        private static IEnumerable<Type> GetLanguageManagers() =>
            GetTypes("AutomatedCodeGeneration.DataLayer.Managers");

        public static LanguageManager GetLanguageManager(string language, SystemModel system)
        {
            LanguageManager manager = null;
            var type = GetLanguageManagers()
                .FirstOrDefault(t => t.Name.ToLower()
                .Equals($"{language.ToLower()}manager")); //2ms

            if (type is not null)
            {
                manager = Activator.CreateInstance(type, system) as LanguageManager; //0-1ms
            }

            return manager;
        }
    }
}
