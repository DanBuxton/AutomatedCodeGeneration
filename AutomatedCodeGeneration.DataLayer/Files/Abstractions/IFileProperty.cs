using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Abstractions
{
    public interface IFileProperty
    {
        List<ClassDataModel> FieldsAndProperties { get; }
    }
}