using System;

namespace AutomatedCodeGeneration.DataLayer
{
    public sealed record AccessModel
    {
        public int Id { get; internal set; }

        internal AccessType Access { get; set; } = AccessType.Public;

        internal AccessModel()
        {
            
        }

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
