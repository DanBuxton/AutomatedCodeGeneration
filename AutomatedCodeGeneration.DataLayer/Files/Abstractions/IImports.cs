using System.Collections.Generic;

namespace AutomatedCodeGeneration.DataLayer.Files.Abstractions;

public interface IImports
{
    public List<string> Imports { get; }
}