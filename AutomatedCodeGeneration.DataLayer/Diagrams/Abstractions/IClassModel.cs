using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions
{
    internal interface IClassModel : INamespace, IDiagram
    {
        string Name { get; }
        List<ClassMethodModel> Methods { get; }
        List<ClassDataModel> Data { get; }
        Enums.AccessType Access { get; }
        FileType Type { get; }

        List<ClassRelationModel> Relations { get; }
    }
}