using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.Output;

public interface IOutputHandler
{
    string OutputDetails { get; }

    Task<bool> Output(IList<IFileModel> files, CancellationToken token);
}