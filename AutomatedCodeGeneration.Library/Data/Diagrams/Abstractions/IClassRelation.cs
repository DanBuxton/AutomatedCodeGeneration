using AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions
{
    internal interface IClassRelation
    {
        ClassModel Target { get; set; }
        ClassRelationType RelationType { get; set; }
    }
}