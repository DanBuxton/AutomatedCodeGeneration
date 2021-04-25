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
                if (!DbOk)
                    return null;

                var system = await GetSystem(_id);// ?? GetModel();

                if (system is null)
                    throw new InvalidOperationException("Can't find Id");

                LanguageManager mgr = new(system);

                mgr.SetLanguageHandler(_languageStrategy);
                mgr.SetOutputHandler(_output);

                //IOutputHandler handler = _output.ToLower().StartsWith("github: ")
                //    ? new GithubHandler()
                //    : new FileHandler();

                return mgr.OutputFiles(cancellationToken);

            }, cancellationToken);
        }
    }
}
