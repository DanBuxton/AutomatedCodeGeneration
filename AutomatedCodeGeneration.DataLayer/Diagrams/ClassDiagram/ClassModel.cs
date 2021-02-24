using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram
{
    public class ClassModel : IClassModel, INameSpace
    {
        public Guid Id { get; set; }
        public virtual SystemModel System { get; set; }
        string INameSpace.NameSpace { get; init; }
        public string Name { get; set; }
        public virtual List<ClassMethodModel> Methods { get; set; } = new();
        public virtual List<ClassDataModel> Data { get; set; } = new();
        public virtual AccessModel Access { get; set; }
    }
}
