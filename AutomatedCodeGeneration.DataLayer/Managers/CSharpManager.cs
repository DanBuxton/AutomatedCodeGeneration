using System;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Files;
using AutomatedCodeGeneration.DataLayer.Files.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.DataLayer.Managers
{
    public sealed class CSharpManager : LanguageManager
    {
        //public CSharpManager() : this(null)
        //{

        //}
        public CSharpManager(SystemModel model) : base(model)
        {
            Extension = "cs";
        }

        public override void GenerateFiles()
        {
            Model.Classes.ForEach(GenerateFile);
        }

        public override Task GenerateFilesAsync()
        {
            Parallel.ForEach(Model.Classes,
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount / 2
                }, GenerateFile);

            return null;
        }

        private void GenerateFile(ClassModel c)
        {
            CSharpFileBuilder builder = new();
            builder.WithImports(new List<string> { "System", "System.Collections.Generic" })
                .WithNamespace(c.Namespace)
                .WithClassAccess(c.Access)
                .WithClassName(c.Name);

            Files.Add(builder.Build() as CSharpFileModel);
        }
    }
}
