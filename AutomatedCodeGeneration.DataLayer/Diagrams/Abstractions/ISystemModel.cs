using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface ISystemModel : INamespace
    {
        Guid Id { get; set; }
        List<UseCaseModel> UseCases { get; set; }
        List<ClassModel> Classes { get; set; }

        bool BeenGenerated { get; set; }
    }
}