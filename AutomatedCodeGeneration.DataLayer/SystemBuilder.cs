using System;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Data;
using AutomatedCodeGeneration.DataLayer.Managers;
using AutomatedCodeGeneration.DataLayer.Managers.Output;
using AutomatedCodeGeneration.DataLayer.Managers.Strategy;

namespace AutomatedCodeGeneration.DataLayer
{
    public sealed class SystemBuilder : DataAccess
    {
        private readonly Guid _id;
        private readonly IOutputHandler _output;

        private readonly Strategy _languageStrategy;

        public SystemBuilder(SystemInfo systemInfo)
        {
            // Only need to know the system id outside of this method
            var (id, lang, output) = systemInfo;
            _id = id;

            _languageStrategy = GetLanguageStrategy(lang);
#if DEBUG
            _output = new FileHandler(output);
#elif RELEASE
            _output = new GithubHandler(output);
#endif
        }

        private static Strategy GetLanguageStrategy(string language) =>
            Helper.GetLanguage(language) switch
            {
                Enums.Languages.CSharp => new CSharpStrategy(),
                Enums.Languages.Java => new JavaStrategy(),
                _ => throw new InvalidOperationException($"Generation not supported for {language}")
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<object> CreateSystem(CancellationToken cancellationToken)
        {
            return await Task.Run(async () =>
            {
                // Check database is running
                if (!DbOk)
                    return null;

                // Get the system from database and map to models - Entity Framework ORM
                var system = await GetSystem(_id);

                // Check the system is found
                if (system is null)
                    throw new InvalidOperationException("Can't find Id");

                // Instantiate a language manager to use the system model from the database
                LanguageManager mgr = new(system);

                // Set the language manager's language strategy based on constructor setup
                mgr.SetLanguageHandler(_languageStrategy);

                // Set target output for the generated system
                mgr.SetOutputHandler(_output);

                // Generate and output code files based on requested language and output
                return mgr.OutputFiles(cancellationToken);
            }, cancellationToken);
        }
    }
}
