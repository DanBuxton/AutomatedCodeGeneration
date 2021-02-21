using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.Library.Data.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram
{
    internal class ClassModel : IClassModel, INameSpace
    {
        public Guid Id { get; set; }
        public virtual SystemModel System { get; set; }
        public string NameSpace { get; init; }
        public string Name { get; set; }
        public virtual List<ClassMethodModel> Methods { get; set; } = new();
        public virtual List<ClassDataModel> Data { get; set; } = new();
        public virtual AccessModel Access { get; set; }
    }
}
