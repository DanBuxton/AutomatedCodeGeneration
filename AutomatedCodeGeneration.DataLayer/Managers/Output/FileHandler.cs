using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.Output
{
    /// <summary>
    /// For testing purposes only
    /// </summary>
    // TODO: Remove this class
    public sealed class FileHandler : IOutputHandler
    {


        public Task<bool> Output(string output, IList<IFileModel> files, CancellationToken token = default)
        {
            return Task.Run(() => true, token);
        }

        public void SetOutput(string output)
        {
            throw new System.NotImplementedException();
        }
    }
}