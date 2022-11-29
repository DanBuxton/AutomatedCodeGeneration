using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.Java;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders.Java;

public class JavaInterfaceFileBuilder : IInterfaceFileBuilder
{
    private readonly JavaInterfaceFileModel _model;

    public JavaInterfaceFileBuilder(string indent = "\t", string newLine = "\n")
    {
        _model = new JavaInterfaceFileModel(indent, newLine);
    }

    public IInterfaceFileBuilder WithImports([NotNull] List<string> imports)
    {
        _model.Imports = imports;

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