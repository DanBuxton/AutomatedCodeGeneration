using System;
using System.IO;
using Xunit;

namespace AutomatedCodeGeneration.Tests
{
    public class HelperTests
    {
        [Theory]
        [InlineData("CSharp")]
        [InlineData("CSharP")]
        [InlineData("CSHArP")]
        [InlineData("csharp")]
        [InlineData("CSHARP")]
        public void Language_Exists_Test(string lang)
        {
            var result = Helper.LanguageExists(lang);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("ThisLanguageDoesNotExist")]
        [InlineData("brainfuck")]
        [InlineData(null)]
        public void Language_Not_Exist_Test(string lang)
        {
            var result = Helper.LanguageExists(lang);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("aef3af89-f90a-4670-bcb0-ff7693325faa", "CSharp", ".")]
        [InlineData("aef3af89-f90a-4670-bcb0-ff7693325faa", "CSharp")]
        public void CreateSystemInfo_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);

            var (actualId, actualLang, actualOutput) = Helper.CreateSystemInfo(goodId, lang, output);

            Assert.Equal(goodId, actualId);
            Assert.Equal(lang, actualLang);
            Assert.Equal(output ?? Directory.GetCurrentDirectory(), actualOutput);
        }
    }
}
