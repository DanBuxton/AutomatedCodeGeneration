using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp
{
    public class CSharpInterfaceFileBuilder : IFileBuilder
    {
        private readonly CSharpInterfaceFileModel _model;

        public CSharpInterfaceFileBuilder(string indent = "\t", string newLine = "\n")
        {
            _model = new CSharpInterfaceFileModel(indent, newLine);
        }

        public CSharpInterfaceFileBuilder WithImports([NotNull] List<string> imports)
        {
            _model.Imports = imports.ToList();

            return this;
        }

        public CSharpInterfaceFileBuilder WithNamespace(string ns)
        {
            _model.Namespace = ns;

            return this;
        }

        //public CSharpInterfaceFileBuilder WithAttributes(List<string> attributes)
        //{
        //    _model.Attributes = attributes;

        //    return this;
        //}

        public CSharpInterfaceFileBuilder WithAccess(Enums.AccessType access)
        {
            _model.Access = access.AsLowerString();

            return this;
        }

        public CSharpInterfaceFileBuilder WithName(string name)
        {
            _model.FileName = name;

            return this;
        }

        //public CSharpInterfaceFileBuilder WithFieldsAndProperties(List<ClassDataModel> fieldsAndProperties)
        //{
        //    _model.FieldsAndProperties = fieldsAndProperties;

        //    return this;
        //}

        //public CSharpInterfaceFileBuilder WithConstructors(List<ClassMethodModel> constructors)
        //{
        //    _model.Constructors = constructors;

        //    return this;
        //}

        public CSharpInterfaceFileBuilder WithMethods(List<ClassMethodModel> methods)
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