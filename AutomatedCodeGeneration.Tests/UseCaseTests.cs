using System;
using AutomatedCodeGeneration.Library;
using AutomatedCodeGeneration.Models;
using Xunit;

namespace AutomatedCodeGeneration.Tests
{
    public class UseCaseTests
    {
        [Theory]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325faa", "CSharp", ".")]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325fab", "CSharp")]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325fac", "Python")]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325fad", "JavaScript")]
        public async void Main_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);

            var result = await SystemGenerator.CreateSystem(new SystemInfo(goodId, lang, output));

            Assert.True(result.HasError);
        }
    }
}
