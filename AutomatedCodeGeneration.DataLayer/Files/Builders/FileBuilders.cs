using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public interface IFileBuilder
    {
        IFileModel Build();
    }
    public interface IClassFileBuilder : IFileBuilder
    {
        public IClassFileBuilder WithNamespace(string ns);

        public IClassFileBuilder WithAttributes(List<string> attributes);

        public IClassFileBuilder WithClassAccess(Enums.AccessType access);

        public IClassFileBuilder WithClassName(string name);

        public IClassFileBuilder WithFieldsAndProperties(List<ClassDataModel> fieldsAndProperties);

        public IClassFileBuilder WithConstructors(List<ClassMethodModel> constructors);

        public IClassFileBuilder WithMethods(List<ClassMethodModel> methods);
    }
    public interface IInterfaceFileBuilder : IFileBuilder
    {
        public IInterfaceFileBuilder WithNamespace(string ns);

        public IInterfaceFileBuilder WithAttributes(List<string> attributes);

        public IInterfaceFileBuilder WithAccess(Enums.AccessType access);

        public IInterfaceFileBuilder WithName(string name);

        public IInterfaceFileBuilder WithMethods(List<ClassMethodModel> methods);
    }
}