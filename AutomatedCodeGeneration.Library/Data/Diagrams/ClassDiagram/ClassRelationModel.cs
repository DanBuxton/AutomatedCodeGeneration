using System;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram
{
    internal class ClassRelationModel : IClassRelation
    {
        public Guid Id { get; set; }
        public virtual ClassModel Target { get; set; }
        public virtual ClassRelationType RelationType { get; set; }
    }
}