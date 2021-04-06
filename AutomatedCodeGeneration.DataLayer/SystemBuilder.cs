using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Data;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Managers;
using AutomatedCodeGeneration.DataLayer.Managers.Output;
using AutomatedCodeGeneration.DataLayer.Managers.Strategy;

namespace AutomatedCodeGeneration.DataLayer
{
    public sealed class SystemBuilder : DataAccess
    {
        private readonly Guid _id;
        private readonly string _language;
        private readonly string _output;

        public SystemBuilder(SystemInfo systemInfo)
        {
            (_id, _language, _output) = systemInfo;
        }

        public async Task<object> CreateSystem(CancellationToken cancellationToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var system = await GetSystem(_id) ?? GetModel();
                    Console.WriteLine(system.Id);

                    var mgr = Helper.GetLanguageManager(_language, system);

                    switch (Helper.GetLanguage(_language))
                    {
                        case Enums.Languages.CSharp:
                            mgr.SetLanguageHandler(new CSharpStrategy());
                            break;
                        case Enums.Languages.Java:
                            mgr.SetLanguageHandler(null);
                            break;
                        default:
                            mgr.SetLanguageHandler(null);
                            throw new InvalidOperationException();
                    }
                    
                    //IOutputHandler handler = _output.ToLower().StartsWith("github: ")
                    //    ? new GithubHandler()
                    //    : new FileHandler();

#if DEBUG
                    mgr.SetOutputHandler(new FileHandler());
#elif RELEASE
                    mgr.SetOutputHandler(new GithubHandler());
#endif

                    //await mgr.OutputFiles(_output, cancellationToken);

                    await mgr.GenerateFilesAsync();

                    //await mgr.GenerateFiles();

                    //await mgr.UploadFiles(_output, new List<IFileModel>(), cancellationToken);

                    //await mgr.UploadToGitHub(_output, new List<IFileModel>(), cancellationToken);
#if DEBUG
                    Console.WriteLine($"Language manager: {mgr.GetType().Name}");
#endif
                }
                catch (Exception e)
                {
#if DEBUG
                    return new InvalidOperationException(e.Message, e);
#elif RELEASE
                    return new InvalidOperationException("Sorry, there was an error generating your code!", e);
#endif
                }

                return null;
            }, cancellationToken);

        }

        private static SystemModel GetModel()
        {
            SystemModel model = new()
            {
                Id = Guid.Parse("234e024d-d03f-4158-0fb9-08d8e15373c5"),
                Namespace = "ACG"
            };
            var classes = new List<ClassModel>
            {
                new()
                {
                    Namespace = "ACG.CLI",
                    Name = "Program",
                    Access = AccessType.Public,
                    Methods = new List<ClassMethodModel>
                    {
                        new()
                        {
                            Access = AccessType.Public,
                            NameType = new NameTypeModel {Name = "Main", Type = "void", IsStatic = true},
                            Params = new List<NameTypeModel>
                            {
                                new() { Name = "args", Type = "string[]"}
                            }
                        }
                    }
                }
            };

            model.Classes = classes;

            return model;
        }
    }
}
