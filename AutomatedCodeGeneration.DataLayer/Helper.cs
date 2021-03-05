using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutomatedCodeGeneration.DataLayer.Manager;

namespace AutomatedCodeGeneration.DataLayer
{
    public static class Helper
    {
        public static string ToString(AccessType access) =>
            access switch
            {
                AccessType.Internal or AccessType.Private or AccessType.Protected or AccessType.Public => access.ToString().ToLower(),
                AccessType.ProtectedInternal => "protected internal",
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}