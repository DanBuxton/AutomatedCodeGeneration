using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Managers.LanguageStrategy
{
    public class CSharpStrategy : Strategy
    {
        protected override IClassFile GenerateClassFile(ClassModel model)
        {
            return new CSharpClassFileBuilder()
                .WithNamespace(model.Namespace)
                .WithAccess(model.Access)
                .WithName(model.Name)
                .WithFieldsAndProperties(model.Data)
                .WithMethods(model.Methods)
                .WithRelations(model.Relations)
                .Build() as IClassFile;
        }

        protected override IInterfaceFile GenerateInterfaceFile(ClassModel model)
        {
            return new CSharpInterfaceFileBuilder()
                .WithNamespace(model.Namespace)
                .WithAccess(model.Access)
                .WithName(model.Name)
                .WithMethods(model.Methods)
                .Build() as IInterfaceFile;
        }
    }
}