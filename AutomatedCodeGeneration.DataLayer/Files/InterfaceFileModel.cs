using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Files;

public abstract class InterfaceFileModel : FileModel, IInterfaceFile
{
    public List<string> Imports { get; set; } = new();

    public string Namespace { get; set; }

    public List<string> Attributes { get; set; } = new();
    public string Access { get; set; }
    
    public List<ClassMethodModel> Methods { get; set; } = new();
}