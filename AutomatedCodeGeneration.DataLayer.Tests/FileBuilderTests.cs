using System;
using System.Collections.Generic;
using System.IO;
using AutomatedCodeGeneration.DataLayer.Files.Builders;
using Xunit;
using Xunit.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Tests
{
    public sealed class FileBuilderTests
    {
        private readonly ITestOutputHelper _output;

        public FileBuilderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CSharp_Test()
        {
            const string indent = "    ", newLine = "\n\r";
            var result = new CSharpFileBuilder(indent, newLine)
                .WithImports(new List<string> {"System"})
                .WithNamespace("ACG").WithClassName("Test")
                .WithClassAccess(AccessType.Public)
                .Build().ToString();

            var expected = $"using System;{newLine}{newLine}namespace ACG{newLine}{{{newLine}{indent}public class Test{newLine}" +
                           $"{indent}{{{newLine}{indent}{indent}{newLine}{indent}}}{newLine}}}";

#if DEBUG
            _output.WriteLine($"Expected:\n\n{expected}\n");
            _output.WriteLine($"Result:\n\n{result}");
            _output.WriteLine($"Result:\n\n{Environment.NewLine}");
#endif

            Assert.Equal(expected, result);
        }
    }
}