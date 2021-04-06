using AutomatedCodeGeneration.DataLayer.Diagrams;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Managers.Output;
using AutomatedCodeGeneration.DataLayer.Managers.Strategy;

namespace AutomatedCodeGeneration.DataLayer.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class LanguageManager
    {
        protected readonly List<IFileModel> Files = new();
        protected readonly SystemModel Model;
        
        protected internal string Extension;

        private IOutputHandler _output;
        private ILanguageManager _language;

        protected LanguageManager(SystemModel model, string ext)
        {
            Model = model;
            Extension = ext;
        }

        public void SetOutputHandler(IOutputHandler handler) => _output = handler;
        public void SetLanguageHandler(ILanguageManager handler) => _language = handler;

        public async Task<bool> OutputFiles(string output, CancellationToken cancellationToken = default)
        {
            return await _output.Output(output, Files, cancellationToken);
        }

        public abstract void GenerateFiles();
        public abstract Task GenerateFilesAsync();

        //public virtual Task OutputFile(IFileModel file, string path)
        //{


        //    return null;
        //}

        ////For testing purposes
        //public async Task<bool> OutputFiles(string path)
        //{
        //    try
        //    {
        //        foreach (var file in Files)
        //        {
        //            await OutputFile(file, path);

        //            var filePath = $"{path}\\{file.ClassName}.{Extension}";

        //            if (File.Exists(filePath)) continue;

        //            await File.WriteAllTextAsync(filePath, file.ToString());
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new IOException("There was an error creating/writing content to the files", e);
        //    }
        //}
    }
}
