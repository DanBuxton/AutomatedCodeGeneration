﻿using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Files;

public abstract class ClassFileModel : FileModel, IClassFile
{
    public List<string> Imports { get; set; } = new();

    public string Namespace { get; set; }

    public List<string> ClassAttributes { get; set; } = new();
    public string ClassAccess { get; set; }

    public List<ClassDataModel> FieldsAndProperties { get; set; } = new();
    public List<ClassMethodModel> Constructors { get; set; } = new();
    public List<ClassMethodModel> Methods { get; set; } = new();

    public List<ClassRelationModel> Relations { get; set; } = new();
}