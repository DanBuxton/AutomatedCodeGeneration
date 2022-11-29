using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp;

public class CSharpClassFileBuilder : IClassFileBuilder
{
    private readonly CSharpClassFileModel _model;

    public CSharpClassFileBuilder(string indent = "\t", string newLine = "\n")
    {
        _model = new CSharpClassFileModel(indent, newLine);
    }

    public IClassFileBuilder WithImports([NotNull] List<string> imports)
    {
        imports.Add("System");
        _model.Imports = imports.RemoveDuplicates();

        return this;
    }

    public IClassFileBuilder WithNamespace(string ns)
    {
        _model.Namespace = ns;

        return this;
    }

    public IClassFileBuilder WithAttributes(List<string> attributes)
    {
        _model.ClassAttributes = attributes.RemoveDuplicates();

        return this;
    }

    public IClassFileBuilder WithAccess(Enums.AccessType access)
    {
        _model.ClassAccess = access.AsLowerString();

        return this;
    }

    public IClassFileBuilder WithName(string name)
    {
        _model.FileName = name;

        return this;
    }

    public IClassFileBuilder WithFieldsAndProperties(List<ClassDataModel> fieldsAndProperties)
    {
        _model.FieldsAndProperties = fieldsAndProperties.RemoveDuplicates();

        return this;
    }

    public IClassFileBuilder WithConstructors(List<ClassMethodModel> constructors)
    {
        _model.Constructors = constructors.RemoveDuplicates();

        return this;
    }

    public IClassFileBuilder WithMethods(List<ClassMethodModel> methods)
    {
        _model.Methods = methods.RemoveDuplicates();

        return this;
    }

    public IClassFileBuilder WithRelations(List<ClassRelationModel> relations)
    {
        //var list = new List<string>(_model.Imports);
        //list.AddRange(relations.Select(r => r.Target.Namespace));

        //WithImports(list);

        _model.Relations = relations;

        return this;
    }

    public IFileModel Build()
    {
        return _model;
    }
}