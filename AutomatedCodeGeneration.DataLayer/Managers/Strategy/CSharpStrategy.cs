using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.Abstractions;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Builders;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Managers.Strategy
{
    public class CSharpStrategy : Strategy
    {
        public override IClassFile GenerateClassFile(ClassModel model)
        {
            return new CSharpClassFileBuilder()
                .WithClassAccess(model.Access)
                .WithClassName(model.Name)
                .WithNamespace(model.Namespace)
                .WithMethods(model.Methods)
                .WithFieldsAndProperties(model.Data)
                .Build() as CSharpClassFileModel;
        }

        public override IInterfaceFile GenerateInterfaceFile(ClassModel model)
        {
            return new CSharpInterfaceFileBuilder()
                .WithNamespace(model.Namespace)
                .WithAccess(model.Access)
                .WithName(model.Name)
                .Build() as IInterfaceFile;
        }
    }
}