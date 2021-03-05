using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Diagrams
{
    public class SystemModel : ISystemModel
    {
        public Guid Id { get; set; }
        public string Namespace { get; init; }

        public virtual List<UseCaseModel> UseCases { get; set; } = new();
        public virtual List<ClassModel> Classes { get; set; } = new();

        public bool BeenGenerated { get; set; } = false;
    }
}
