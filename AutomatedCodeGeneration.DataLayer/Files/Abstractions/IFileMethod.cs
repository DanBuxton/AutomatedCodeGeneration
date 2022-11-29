using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Abstractions;

public interface IFileMethod
{
    List<ClassMethodModel> Methods { get; }
}