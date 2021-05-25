using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Data;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Managers;
using AutomatedCodeGeneration.DataLayer.Managers.LanguageStrategy;
using AutomatedCodeGeneration.DataLayer.Managers.Output;

namespace AutomatedCodeGeneration.DataLayer
{
    public abstract class SystemBuilder : DataAccess
    {
        private SystemBuilder() { }

        private static Strategy GetLanguageStrategy(string language) =>
            Helper.GetLanguage(language) switch
            {
                Enums.Languages.CSharp => new CSharpStrategy(),
                Enums.Languages.Java => new JavaStrategy(),
                _ => throw new InvalidOperationException($"Generation not supported for {language}")
            };

        public static async Task<IOException> CreateSystem(SystemInfo systemInfo, CancellationToken cancellationToken)
        {
            try
            {
                // Deconstruct the system information into usable variables
                var (id, lang, output) = systemInfo;

                var languageStrategy = GetLanguageStrategy(lang);

                IOutputHandler outputHandler = output[..8].Equals("github::")
                    ? new GithubHandler(output[8..], id.ToString())
                    : new FileHandler(output);

                // Check database is running
                if (!DbOk)
                    return null;

                // Get the system from database and map to models - Entity Framework ORM
                var system = await GetSystem(id);

                // Check the system is found
                if (system is null)
                    throw new InvalidOperationException("Can't find Id");

                // Instantiate a language manager to use the system model from the database
                LanguageManager mgr = new(system);

                // Set the language manager's language strategy based on constructor setup
                mgr.SetLanguageHandler(languageStrategy);

                // Set target output for the generated system
                mgr.SetOutputHandler(outputHandler);

                // Generate and output code files based on requested language and output
                var isOk = await mgr.OutputFiles(cancellationToken);

                if (isOk)
                {
#if DEBUG
                    if (id.Equals(new Guid("0a866869-1bc1-4ac6-c627-08d91fb3b958")) || id.Equals(new Guid("21189b61-44e8-444c-16f8-08d91fb46754")))
                    {
                        return null;
                    }
#endif

                    //Update database
                    await MarkSystemAsGenerated(system.Id);

                    return null;
                }
            }
            catch (Exception e)
            {
                //throw;
                return new IOException(e.Message, e);
            }

            return new IOException("There was an issue completing your request");
        }

        public static async Task<Guid> CreateSystem(SystemModel model) => (await AddSystem(model)).Id;
    }
}
