using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public interface IClassFileBuilder : IFileBuilder
    {
        public IClassFileBuilder WithNamespace(string ns);

        public IClassFileBuilder WithAttributes(List<string> attributes);

        public IClassFileBuilder WithAccess(Enums.AccessType access);

        public IClassFileBuilder WithName(string name);

        public IClassFileBuilder WithFieldsAndProperties(List<ClassDataModel> fieldsAndProperties);

        public IClassFileBuilder WithConstructors(List<ClassMethodModel> constructors);

        public IClassFileBuilder WithMethods(List<ClassMethodModel> methods);
    }
}