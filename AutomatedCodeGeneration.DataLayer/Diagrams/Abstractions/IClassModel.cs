using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface IClassModel : IDiagram
    {
        string Name { get; set; }
        List<ClassMethodModel> Methods { get; set; }
        List<ClassDataModel> Data { get; set; }
        AccessType Access { get; set; }
    }
}