using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram
{
    public class ClassMethodModel : IClassMethod
    {
        public Guid Id { get; set; }
        public virtual NameTypeModel NameType { get; init; }
        public AccessType Access { get; init; }
        public virtual List<NameTypeModel> Params { get; init; } = new();
    }
}
