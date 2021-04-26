using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public interface IInterfaceFileBuilder : IFileBuilder
    {
        public IInterfaceFileBuilder WithNamespace(string ns);

        public IInterfaceFileBuilder WithAttributes(List<string> attributes);

        public IInterfaceFileBuilder WithAccess(Enums.AccessType access);

        public IInterfaceFileBuilder WithName(string name);

        public IInterfaceFileBuilder WithMethods(List<ClassMethodModel> methods);
    }
}