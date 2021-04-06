using AutomatedCodeGeneration.DataLayer.Files.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Managers.Strategy
{
    public interface ILanguageManager
    {
        void GenerateClassFile(IClassFile file);

        void GenerateInterfaceFile(IInterfaceFile file);

        void GenerateFile(IFileModel file);
    }
}