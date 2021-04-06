using System;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Files;
using AutomatedCodeGeneration.DataLayer.Files.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Managers
{
    public sealed class CSharpManager : LanguageManager
    {
        public CSharpManager(SystemModel model) : base(model, "cs")
        {
        }

        public override void GenerateFiles()
        {
            //Model.Classes.ForEach(GenerateFile);

            foreach (var model in Model.Classes)
            {
                GenerateFile(model);
            }
        }

        public override Task GenerateFilesAsync()
        {
            Parallel.ForEach(Model.Classes,
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount / 2
                }, GenerateFile);

            return Task.CompletedTask;
        }

        private void GenerateFile(ClassModel c)
        {
            CSharpFileBuilder builder = new();
            builder.WithImports(new List<string> { "System", "System.Collections.Generic" })
                .WithNamespace(c.Namespace)
                .WithClassAccess(c.Access)
                .WithClassName(c.Name)
                .WithMethods(c.Methods);

            Files.Add(builder.Build() as CSharpClassFileModel);
        }

        public void GenerateClassFile(IObjectOrientedFile c)
        {
            throw new NotImplementedException();
        }

        public void GenerateFile(FileModel file)
        {
            throw new NotImplementedException();
        }
    }
}
