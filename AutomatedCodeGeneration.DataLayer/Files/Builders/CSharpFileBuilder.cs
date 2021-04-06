using System.Collections.Generic;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public class CSharpFileBuilder : IFileModelBuilder
    {
        private readonly CSharpClassFileModel _model;
        public FileModel ModelType { get; }

        public CSharpFileBuilder(string indent = "\t", string newLine = "\n")
        {
            _model = new CSharpClassFileModel(indent, newLine);
            ModelType = _model;
        }

        public CSharpFileBuilder WithImports(IEnumerable<string> imports)
        {
            _model.Imports = imports.ToList();

            if (!_model.Imports.Contains("System"))
                _model.Imports.Insert(0, "System");

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

        public CSharpFileBuilder WithFieldsAndProperties(List<ClassDataModel> fieldsAndProperties)
        {
            _model.FieldsAndProperties = fieldsAndProperties;

            return this;
        }

        public CSharpFileBuilder WithConstructors(List<ClassMethodModel> constructors)
        {
            _model.Constructors = constructors;

            return this;
        }

        public CSharpFileBuilder WithMethods(List<ClassMethodModel> methods)
        {
            _model.Methods = methods;

            return this;
        }

        public FileModel Build()
        {
            return _model;
        }
    }
}