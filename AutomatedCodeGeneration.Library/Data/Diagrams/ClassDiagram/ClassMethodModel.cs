using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram
{
    internal class ClassMethodModel : IClassMethod
    {
        public Guid Id { get; set; }
        public virtual NameTypeModel NameType { get; init; }
        public virtual AccessModel Access { get; init; }
        public virtual List<NameTypeModel> Params { get; init; } = new();
    }
}
