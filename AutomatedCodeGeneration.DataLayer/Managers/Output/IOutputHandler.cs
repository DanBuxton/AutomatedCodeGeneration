using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.Output
{
    public interface IOutputHandler
    {
        Task<bool> Output(string output, IList<IFileModel> files, CancellationToken token = default);

        void SetOutput(string output);
    }
}