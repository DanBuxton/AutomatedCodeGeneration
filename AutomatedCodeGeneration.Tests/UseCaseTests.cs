using System;
using AutomatedCodeGeneration.DataLayer;
using AutomatedCodeGeneration.Models;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AutomatedCodeGeneration.Tests
{
    public class UseCaseTests
    {
        private readonly ITestOutputHelper _output;

        public UseCaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325faa", "CSharp", ".")]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325fab", "CSharp")]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325fac", "Python")]
        [InlineData("aff3af89-f90a-4670-bcb0-ff7693325fad", "JavaScript")]
        public async void SystemGenerator_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);

            var result = await SystemGenerator.CreateSystem(new SystemInfo(goodId, lang, output));

            _output.WriteLine($"ERROR: {result.Error}");

            Assert.True(result.HasError);
        }
    }
}
