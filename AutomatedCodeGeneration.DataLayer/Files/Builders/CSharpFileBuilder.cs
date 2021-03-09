using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public class CSharpFileBuilder : IFileModelBuilder
    {
        private readonly CSharpFileModel _model;
        public FileModel ModelType { get; }

        public CSharpFileBuilder(string indent = "\t", string newLine = "\n")
        {
            _model = new CSharpFileModel(indent, newLine);
            ModelType = _model;
        }

        public CSharpFileBuilder WithImports(IEnumerable<string> imports)
        {
            _model.Imports = imports.ToList();

            return this;
        }

        public CSharpFileBuilder WithNamespace(string ns)
        {
            _model.Namespace = ns;

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

        public FileModel Build()
        {
            return _model;
        }
    }
}