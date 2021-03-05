using System;
using System.Collections.Generic;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public class CSharpFileBuilder : IBuilder
    {
        private readonly CSharpFileModel _model;
        public FileModel ModelType { get; }

        public CSharpFileBuilder(string indent = "\t", string newLine = "\n")
        {
            _model = new CSharpFileModel(indent, newLine);
            ModelType = _model;
        }

        public CSharpFileBuilder WithImports(List<string> imports)
        {
            _model.Imports = imports;

            return this;
        }

        public CSharpFileBuilder WithNamespace(string @namespace)
        {
            _model.Namespace = @namespace;

            return this;
        }

        public CSharpFileBuilder WithClassAttributes(List<string> attributes)
        {
            _model.ClassAttributes = attributes;

            return this;
        }

        public CSharpFileBuilder WithClassAccess(AccessType access)
        {
            _model.ClassAccess = Helper.ToString(access);

            return this;
        }

        public CSharpFileBuilder WithClassName(string name)
        {
            _model.ClassName = name;

            return this;
        }

        public CSharpFileBuilder WithFieldsAndProperties(List<string> fieldsAndProperties)
        {
            _model.FieldsAndProperties = fieldsAndProperties;

            return this;
        }

        public CSharpFileBuilder WithConstructors(List<string> constructors)
        {
            _model.Constructors = constructors;

            return this;
        }

        public string Build()
        {
            return _model.ToString();
        }
    }
}