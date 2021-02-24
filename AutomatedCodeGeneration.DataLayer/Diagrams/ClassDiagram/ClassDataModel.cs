using System;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram
{
    public class ClassDataModel : IClassData
    {
        public Guid Id { get; set; }
        public virtual NameTypeModel NameType { get; init; }
        public virtual AccessModel Access { get; init; }
    }
}
