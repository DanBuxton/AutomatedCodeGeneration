using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Files.Builders;

public interface IFileBuilder
{
    IFileModel Build();
}