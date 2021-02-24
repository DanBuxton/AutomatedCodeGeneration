using System;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram
{
    public class ClassRelationModel : IClassRelation
    {
        public Guid Id { get; set; }
        public virtual ClassModel Target { get; set; }
        public virtual ClassRelationType RelationType { get; set; }
    }
}