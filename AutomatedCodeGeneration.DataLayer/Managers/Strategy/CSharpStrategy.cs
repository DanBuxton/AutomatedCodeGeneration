using AutomatedCodeGeneration.DataLayer.Files;
using AutomatedCodeGeneration.DataLayer.Files.Abstractions;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;

namespace AutomatedCodeGeneration.DataLayer.Managers.Strategy
{
    public class CSharpStrategy : ILanguageManager
    {
        public void GenerateClassFile(IClassFile file)
        {
            if (file is not CSharpClassFileModel)
                throw new System.NotImplementedException();
        }

        public void GenerateInterfaceFile(IInterfaceFile file)
        {
            if (file is not CSharpInterfaceFileModel)
                return;
            // throw new System.NotImplementedException();

                
        }

        public void GenerateFile(IFileModel file)
        {
            throw new System.NotImplementedException();
        }
    }
}