using System;
using System.Collections.Generic;
using System.Linq;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.Strategy
{
    public abstract class Strategy
    {
        public abstract IClassFile GenerateClassFile(ClassModel model);

        public abstract IInterfaceFile GenerateInterfaceFile(ClassModel model);

        public virtual IInterfaceFile GenerateEnumFile(ClassModel model) => null;

        public IFileModel GenerateFile(ClassModel model) =>
            model.Type switch
            {
                FileType.Class => GenerateClassFile(model),
                FileType.Interface => GenerateInterfaceFile(model),
                FileType.Enum => throw new InvalidOperationException("Enums are not yet supported"),
                _ => throw new InvalidOperationException("File type is not supported")
            };

        public List<IFileModel> GenerateFiles(SystemModel model)
        {
            List<IFileModel> models = new();

            models.AddRange(model.Classes.Select(GenerateFile));

            return models;
        }
    }
}