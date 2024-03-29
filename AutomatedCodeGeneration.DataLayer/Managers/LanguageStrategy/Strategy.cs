﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.LanguageStrategy;

public abstract class Strategy
{
    protected abstract IClassFile GenerateClassFile(ClassModel model);

    protected abstract IInterfaceFile GenerateInterfaceFile(ClassModel model);

    protected virtual IFileModel GenerateEnumFile(ClassModel model) => null;

    private IFileModel GenerateFile(ClassModel model) =>
        model.Type switch
        {
            FileType.Class => GenerateClassFile(model),
            FileType.Interface => GenerateInterfaceFile(model),
            FileType.Enum => throw new InvalidOperationException("Enums are in progress"),
            _ => throw new InvalidOperationException("File type is not supported")
        };

    public List<IFileModel> GenerateFiles(SystemModel model)
    {
        List<IFileModel> models = new();

        models.AddRange(model.Classes.Select(GenerateFile));

        return models;
    }
}