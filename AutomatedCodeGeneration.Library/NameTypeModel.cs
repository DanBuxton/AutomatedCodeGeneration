using System;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.Library
{
    public record NameTypeModel : INameSpace
    {
        public Guid Id { get; set; }

        public string Name { get; init; }
        public string Type { get; init; }
        public string NameSpace { get; init; }

        public bool IsStatic { get; init; } = false;
    }
}
