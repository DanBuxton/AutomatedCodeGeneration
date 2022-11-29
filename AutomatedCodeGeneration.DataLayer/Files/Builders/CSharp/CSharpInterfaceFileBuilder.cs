using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp;

public class CSharpInterfaceFileBuilder : IInterfaceFileBuilder
{
    private readonly CSharpInterfaceFileModel _model;

    public CSharpInterfaceFileBuilder(string indent = "\t", string newLine = "\n")
    {
        _model = new CSharpInterfaceFileModel(indent, newLine);
    }

    public IInterfaceFileBuilder WithImports([NotNull] List<string> imports)
    {
        _model.Imports = imports.ToList();

        return this;
    }

    public IInterfaceFileBuilder WithNamespace(string ns)
    {
        _model.Namespace = ns;

        return this;
    }

    public IInterfaceFileBuilder WithAttributes(List<string> attributes)
    {
        _model.Attributes = attributes;

        return this;
    }

    public IInterfaceFileBuilder WithAccess(Enums.AccessType access)
    {
        _model.Access = access.AsLowerString();

        return this;
    }

    public IInterfaceFileBuilder WithName(string name)
    {
        _model.FileName = name;

        return this;
    }

    public IInterfaceFileBuilder WithMethods(List<ClassMethodModel> methods)
    {
        _model.Methods = methods;

        return this;
    }

    public IFileModel Build()
    {
        return _model;
    }
}