using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Abstractions
{
    public interface IClass : IFileProperty, IFileMethod
    {
        string ClassAccess { get; }
        string ClassName { get; }
    }
}