using System;
using System.IO;
using AutomatedCodeGeneration.DataLayer;
using Xunit;
using Xunit.Abstractions;

namespace AutomatedCodeGeneration.Tests
{
    public class SystemInfoTests
    {
        private readonly ITestOutputHelper _output;

        public SystemInfoTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Id_Get_Test()
        {
            SystemInfo systemInfo = new(Guid.Empty, "CSharp");

            Assert.Equal(Guid.Empty, systemInfo.Id);
        }

        [Fact]
        public void Language_Get_Test()
        {
            SystemInfo systemInfo = new(Guid.Empty, "CSharp");

            Assert.Equal("CSharp", systemInfo.TargetLanguage);
        }

        [Fact]
        public void Empty_Output_Get_Test()
        {
            SystemInfo systemInfo = new(Guid.Empty, "CSharp");

            Assert.Equal(Directory.GetCurrentDirectory(), systemInfo.Output);
        }

        [Theory]
        [InlineData(".")]
        [InlineData(null)]
        public void Output_Get_Test(string output)
        {
            SystemInfo systemInfo = new(Guid.Empty, "CSharp", output);

            Assert.Equal(output ?? Directory.GetCurrentDirectory(), systemInfo.Output);
        }

        [Theory]
        [InlineData("aef3af89-f90a-4670-bcb0-ff7693325faa", "CSharp", ".")]
        [InlineData("aef3af89-f90a-4670-bcb0-ff7693325faa", "CSharp")]
        public void Deconstruct_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);

            var (actualId, actualLang, actualOutput) = new SystemInfo(goodId, lang, output);

            Assert.Equal(goodId, actualId);
            Assert.Equal(lang, actualLang);
            Assert.Equal(output ?? Directory.GetCurrentDirectory(), actualOutput);
        }
    }
}
