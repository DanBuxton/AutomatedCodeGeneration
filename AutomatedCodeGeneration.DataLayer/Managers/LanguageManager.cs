using AutomatedCodeGeneration.DataLayer.Diagrams;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Managers.Output;
using AutomatedCodeGeneration.DataLayer.Managers.Strategy;

namespace AutomatedCodeGeneration.DataLayer.Managers
{
    public sealed class LanguageManager
    {
        private readonly List<IFileModel> _files = new();
        private readonly SystemModel _model;

        private IOutputHandler _output;
        private Strategy.Strategy _language;

        public LanguageManager(SystemModel model)
        {
            _model = model;
        }

        public void SetOutputHandler(IOutputHandler handler) => _output = handler;
        public void SetLanguageHandler(Strategy.Strategy handler) => _language = handler;

        public async Task<bool> OutputFiles(CancellationToken cancellationToken)
        {
            // Add files to list
            _language.GenerateFiles(_model).ForEach(_files.Add);

            // Output files to github or file system
            return await _output.Output(_files, cancellationToken);
        }
    }
}
