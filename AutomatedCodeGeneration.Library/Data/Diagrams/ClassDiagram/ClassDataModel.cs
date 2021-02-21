using System;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram
{
    internal class ClassDataModel : IClassData
    {
        public Guid Id { get; set; }
        public virtual NameTypeModel NameType { get; init; }
        public virtual AccessModel Access { get; init; }
    }
}
