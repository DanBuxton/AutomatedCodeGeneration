using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

internal interface IClassRelation
{
    ClassModel Target { get; set; }
    ClassRelationType RelationType { get; set; }
}