﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp
{
    public class CSharpClassFileBuilder : IClassFileBuilder
    {
        private readonly CSharpClassFileModel _model;

        public CSharpClassFileBuilder(string indent = "\t", string newLine = "\n")
        {
            _model = new CSharpClassFileModel(indent, newLine);
        }

        public IClassFileBuilder WithImports([NotNull] List<string> imports)
        {
            _model.Imports = imports.ToList();

            return this;
        }

        public IClassFileBuilder WithNamespace(string ns)
        {
            _model.Namespace = ns;

            return this;
        }

        public IClassFileBuilder WithAttributes(List<string> attributes)
        {
            _model.ClassAttributes = attributes;

            return this;
        }

        public IClassFileBuilder WithAccess(Enums.AccessType access)
        {
            _model.ClassAccess = access.AsLowerString();

            return this;
        }

        public IClassFileBuilder WithName(string name)
        {
            _model.ClassName = name;

            return this;
        }

        public IClassFileBuilder WithFieldsAndProperties(List<ClassDataModel> fieldsAndProperties)
        {
            _model.FieldsAndProperties = fieldsAndProperties;

            return this;
        }

        public IClassFileBuilder WithConstructors(List<ClassMethodModel> constructors)
        {
            _model.Constructors = constructors;

            return this;
        }

        public IClassFileBuilder WithMethods(List<ClassMethodModel> methods)
        {
            _model.Methods = methods;

            return this;
        }

        public IFileModel Build()
        {
            return _model;
        }
    }
}