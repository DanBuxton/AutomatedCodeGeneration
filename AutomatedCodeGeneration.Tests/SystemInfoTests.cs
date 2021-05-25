using System;
using System.IO;
using Xunit;

namespace AutomatedCodeGeneration.Tests
{
    public class SystemInfoTests
    {
        [Fact]
        public void Id_Get_Test()
        {
            var systemInfo = Helper.CreateSystemInfo(Guid.Empty, "CSharp", null);

            Assert.Equal(Guid.Empty, systemInfo.Id);
        }

        [Fact]
        public void Language_Get_Test()
        {
            var systemInfo = Helper.CreateSystemInfo(Guid.Empty, "CSharp", null);

            Assert.Equal("CSharp", systemInfo.TargetLanguage);
        }

        [Fact]
        public void Empty_Output_Get_Test()
        {
            var systemInfo = Helper.CreateSystemInfo(Guid.Empty, "CSharp", null);

            Assert.Equal(Directory.GetCurrentDirectory(), systemInfo.Output);
        }

        [Theory]
        [InlineData(".")]
        [InlineData(null)]
        public void Output_Get_Test(string output)
        {
            var systemInfo = Helper.CreateSystemInfo(Guid.Empty, "CSharp", output);

            Assert.Equal(output ?? Directory.GetCurrentDirectory(), systemInfo.Output);
        }

        [Theory]
        [InlineData("aef3af89-f90a-4670-bcb0-ff7693325faa", "CSharp", ".")]
        [InlineData("aef3af89-f90a-4670-bcb0-ff7693325faa", "CSharp")]
        public void Deconstruct_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);
            var (actualId, actualLang, actualOutput) = Helper.CreateSystemInfo(goodId, lang, output);

            Assert.Equal(goodId, actualId);
            Assert.Equal(lang, actualLang);
            Assert.Equal(output ?? Directory.GetCurrentDirectory(), actualOutput);
        }
    }
}
