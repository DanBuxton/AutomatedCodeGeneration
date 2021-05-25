using System;
using Xunit;
using Xunit.Abstractions;

namespace AutomatedCodeGeneration.Tests
{
    public class UseCaseTests
    {
        [Theory]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "CSharp", ".")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "CSharp")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "Python", ".")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "Python")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "JavaScript", ".")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "JavaScript")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "Java", ".")]
        [InlineData("234e024d-d03f-4158-0fb9-08d8e15373c5", "java")]
        public async void SystemGenerator_Test(string id, string lang, string output = null)
        {
            var goodId = Guid.Parse(id);

            var result = await SystemGenerator.CreateSystem(Helper.CreateSystemInfo(goodId, lang, output));


            Assert.True(result.HasError);

            return;

            if (!Helper.LanguageExists(lang).HasValue || output != null && output.Equals("."))
            {
                Assert.True(result.HasError);
            }
            else
            {
                Assert.False(result.HasError);
            }
        }
    }
}
