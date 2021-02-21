using System.Collections.Generic;
using AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions
{
    internal interface IClassModel : IDiagram
    {
        string Name { get; set; }
        List<ClassMethodModel> Methods { get; set; }
        List<ClassDataModel> Data { get; set; }
        AccessModel Access { get; set; }
    }
}