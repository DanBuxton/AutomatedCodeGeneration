using System;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders
{
    public interface IBuilder
    {
        public FileModel ModelType { get; }
        string Build();
    }
}