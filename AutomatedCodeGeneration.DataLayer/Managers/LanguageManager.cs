using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedCodeGeneration.DataLayer.Managers
{
    public abstract class LanguageManager
    {
        protected readonly List<FileModel> Files = new();
        protected readonly SystemModel Model;
        
        protected internal string Extension;

        protected LanguageManager(SystemModel model)
        {
            Model = model;
        }

        protected internal bool UploadToGitHub(string token)
        {
            return false;
        }

        public abstract void GenerateFiles();
        public abstract Task GenerateFilesAsync();

        //For testing purposes
        public async Task<bool> OutputFiles(string path)
        {
            try
            {
                foreach (var file in Files)
                {
                    var filePath = $"{path}\\{file.ClassName}.{Extension}";

                    if (File.Exists(filePath)) continue;

                    await File.WriteAllTextAsync(filePath, file.ToString());
                }

                return true;
            }
            catch (Exception e)
            {
                throw new IOException("There was an error creating/writing content to the files", e);
            }
        }
    }
}
