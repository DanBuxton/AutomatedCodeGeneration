using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions
{
    internal interface ISystemModel : INameSpace
    {
        Guid Id { get; set; }
        List<UseCaseModel> UseCases { get; set; }
        List<ClassModel> Classes { get; set; }

        bool BeenGenerated { get; set; }
    }
}