using System.Text;

namespace AutomatedCodeGeneration.DataLayer.Files.Languages
{
    public interface ILanguageFile
    {
        StringBuilder Generate();
    }
}