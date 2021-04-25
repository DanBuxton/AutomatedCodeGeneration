using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Managers.Strategy
{
    public class CSharpStrategy : Strategy
    {
        protected override IClassFile GenerateClassFile(ClassModel model)
        {
            return new CSharpClassFileBuilder()
                .WithAccess(model.Access)
                .WithName(model.Name)
                .WithNamespace(model.Namespace)
                .WithMethods(model.Methods)
                .WithFieldsAndProperties(model.Data)
                .Build() as CSharpClassFileModel;
        }

        protected override IInterfaceFile GenerateInterfaceFile(ClassModel model)
        {
            return new CSharpInterfaceFileBuilder()
                .WithNamespace(model.Namespace)
                .WithAccess(model.Access)
                .WithName(model.Name)
                .Build() as IInterfaceFile;
        }
    }
}