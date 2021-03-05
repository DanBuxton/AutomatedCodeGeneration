using System;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer
{
    public record NameTypeModel : INamespace
    {
        public Guid Id { get; set; }

        public string Name { get; init; }
        public string Type { get; init; }
        public string Namespace { get; init; }
        public bool IsStatic { get; init; } = false;

    }
}
