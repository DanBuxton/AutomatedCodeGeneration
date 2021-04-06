using System;
using AutomatedCodeGeneration.DataLayer;
using AutomatedCodeGeneration.Models;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Helper = AutomatedCodeGeneration.Models.Helper;

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
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "CSharp", ".")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "CSharp")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "Python")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "JavaScript")]
        public async void SystemGenerator_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);

            var result = await SystemGenerator.CreateSystem(new SystemInfo(goodId, lang, output));

            _output.WriteLine($"ERROR: {result.Error}");

            if (Helper.LanguageExists(lang).HasValue)
            {

                Assert.False(result.HasError);
            }
            else
            {
                Assert.True(result.HasError);
            }
        }
    }
}
