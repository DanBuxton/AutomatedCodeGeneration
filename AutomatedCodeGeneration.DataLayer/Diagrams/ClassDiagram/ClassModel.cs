using System;
using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram
{
    public class ClassModel : IClassModel
    {
        public Guid Id { get; set; }
        public virtual SystemModel System { get; set; }
        public string Namespace { get; init; }
        public string Name { get; set; }
        public virtual List<ClassMethodModel> Methods { get; set; } = new();
        public virtual List<ClassDataModel> Data { get; set; } = new();
        public Enums.AccessType Access { get; set; }

        public FileType Type { get; set; } = FileType.Class;

        public virtual List<ClassRelationModel> Relations { get; set; } = new();
    }
}
