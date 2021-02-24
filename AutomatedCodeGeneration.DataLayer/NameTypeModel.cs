using System;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer
{
    public record NameTypeModel : INameSpace
    {
        public Guid Id { get; set; }

        public string Name { get; init; }
        public string Type { get; init; }
        string INameSpace.NameSpace { get; init; }
        public bool IsStatic { get; init; } = false;

    }
}
