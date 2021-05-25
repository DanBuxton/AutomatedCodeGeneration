using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<T> RemoveDuplicates<T>(this List<T> list)
        {
            List<T> result = new(list);

            foreach (var item in list)
            {
                while (result.Count(s => s.Equals(item)) > 1)
                {
                    var index = result.LastIndexOf(item);

                    result.RemoveAt(index);
                }

                //for (var i = result.Count; i >= 0; i--)
                //{
                //    if (result.Count(s => s.Equals(item)) > 1)
                //    {
                //        result.LastIndexOf().RemoveAt(i);
                //    }
                //}
            }

            return result;
        }
    }
}
