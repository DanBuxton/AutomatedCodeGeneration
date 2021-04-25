using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Files;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.Output
{
    public sealed class FileHandler : IOutputHandler
    {
        public string OutputDetails { get; set; }

        public FileHandler(string outputDetails)
        {
            OutputDetails = outputDetails;
        }

        public async Task<bool> Output(IList<IFileModel> files, CancellationToken token)
        {
            try
            {
                foreach (var file in files)
                {

                    var filePath = OutputDetails;

                    if (file is ClassFileModel c)
                    {
                        filePath += $@"\{c.ClassName}.{c.FileExt}";
                    }
                    else
                    {
                        filePath += $@"\{file.FileName}.{file.FileExt}";
                    }

                    if (File.Exists(filePath)) continue;

                    await File.WriteAllTextAsync(filePath, file.Generate().ToString(), token);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new IOException(e.Message, e);
            }
        }
    }
}