using AutomatedCodeGeneration.DataLayer.Files.Builders;
using AutomatedCodeGeneration.DataLayer.Files.Languages.CSharp;
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

        [Theory]
        [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "Program", AccessType.Public, "System", "System.Collections.Generic")]
        [InlineData("\n\r", "\t", "", "TestClassName", AccessType.Public, "System", "System.Collections.Generic", "System.Linq")]
        [InlineData("\n\r", "\t", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public, "System")]
        [InlineData("\n\r", "\t", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public, "System", "System.Collections.Generic")]
        [InlineData("\n\r", "", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public, "System", "System.Collections.Generic")]
        [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public, "System", "System.Collections.Generic")]
        [InlineData("\n", "", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public, "System", "System.Collections.Generic")]
        [InlineData("", "", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public, "System", "System.Collections.Generic")]
        [InlineData("\n", "    ", "AutoMatedCodeGeneration.CLI", "TestClassName", AccessType.Public)]
        public void CSharp_Test(string newLine, string indent, string ns, string name, AccessType access, params string[] imports)
        {
            //const string indent = "    ", newLine = "\n\r";
            var result = new CSharpFileBuilder(indent, newLine)
                .WithImports(imports)
                .WithNamespace(ns).WithClassName(name)
                .WithClassAccess(access)
                .Build().Generate().ToString();

            var hasNamespace = !string.IsNullOrEmpty(ns);

            var expected = "";

            expected = imports.Length > 0 ? $"using {string.Join($";{newLine}using ", imports)}" : "using System";

            expected += $";{newLine}{newLine}";

            var i = 0;

            if (hasNamespace)
            {
                expected += $"namespace {ns}{newLine}{{{newLine}";
                expected = Indent(expected, indent, ++i);
            }

            expected += $"{Helper.ToString(access)} class {name}{newLine}";
            expected = Indent(expected, indent, i);
            expected += $"{{{newLine}";
            expected = Indent(expected, indent, ++i);
            expected += $"{newLine}";
            expected = Indent(expected, indent, --i);
            expected += "}";

            if (hasNamespace)
            {
                expected += $"{newLine}}}";
            }
            
#if DEBUG
            _output.WriteLine($"Expected:\n\n{expected}");
            _output.WriteLine($"Result:\n\n{result}");
#endif

            Assert.Equal(expected, result);
        }

        private static string Indent(string expected, string indent, int i)
        {
            for (var j = 0; j < i; j++)
            {
                expected += indent;
            }

            return expected;
        }
    }
}