using AutomatedCodeGeneration.DataLayer.Diagrams;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Managers.LanguageStrategy;
using AutomatedCodeGeneration.DataLayer.Managers.Output;

namespace AutomatedCodeGeneration.DataLayer.Managers;

public sealed class LanguageManager
{
    private readonly List<IFileModel> _files = new();
    private readonly SystemModel _model;

    //private IOutputHandler _output;
    private Strategy _language;

    public LanguageManager(SystemModel model)
    {
        _model = model;
    }

    //public void SetOutputHandler(IOutputHandler handler) => _output = handler;
    public void SetLanguageHandler(Strategy handler) => _language = handler;

    public async Task<bool> OutputFiles(IOutputHandler output, CancellationToken cancellationToken = default)
    {
        // Add files to list
        _language.GenerateFiles(_model).ForEach(_files.Add);

        // Output files to github or file system
        return await output.Output(_files, cancellationToken);
    }
}
