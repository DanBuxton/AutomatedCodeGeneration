using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Builders;
using AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp;
using AutomatedCodeGeneration.DataLayer.Files.Builders.Java;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;
using AutomatedCodeGeneration.DataLayer.Files.Languages.Java;

namespace AutomatedCodeGeneration.DataLayer.Managers.Strategy
{
    public class JavaStrategy : Strategy
    {
        protected override IClassFile GenerateClassFile(ClassModel model)
        {
            return new JavaClassFileBuilder()
                .WithAccess(model.Access)
                .WithName(model.Name)
                .WithNamespace(model.Namespace)
                .WithMethods(model.Methods)
                .WithFieldsAndProperties(model.Data)
                .Build() as IClassFile;
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