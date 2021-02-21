using System;

namespace AutomatedCodeGeneration.Library
{
    internal record AccessModel
    {
        public int Id { get; set; }

        public AccessType Access { get; set; } = AccessType.Public;

        public override string ToString()
        {
            return Access switch
            {
                AccessType.Internal or AccessType.Private or AccessType.Protected or AccessType.Public => Access.ToString().ToLower(),
                AccessType.ProtectedInternal => "protected internal",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
