using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;
using AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.Library.Data.Diagrams
{
    internal class SystemModel : ISystemModel
    {
        public Guid Id { get; set; }
        public string NameSpace { get; init; }

        public virtual List<UseCaseModel> UseCases { get; set; } = new();
        public virtual List<ClassModel> Classes { get; set; } = new();

        public bool BeenGenerated { get; set; } = false;
    }
}
