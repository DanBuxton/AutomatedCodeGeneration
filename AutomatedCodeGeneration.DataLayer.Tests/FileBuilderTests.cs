using System.Linq;
using AutomatedCodeGeneration.DataLayer.Files.Builders.CSharp;
using AutomatedCodeGeneration.DataLayer.Files.Builders.Java;
using Xunit;

#if DEBUG
using Xunit.Abstractions;
#endif

namespace AutomatedCodeGeneration.DataLayer.Tests
{
    public static class FileBuilderTests
    {
        public sealed class CSharpTest
        {
#if DEBUG
            private readonly ITestOutputHelper _output;

            public CSharpTest(ITestOutputHelper output)
            {
                _output = output;
            }
#endif

            [Theory]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "Program", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\r\n", "\t", "", "MyClass", Enums.AccessType.Public, "System", "System.Collections.Generic", "System.Linq")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public, "System")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "    ", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public)]
            public void Class_Test(string newLine, string indent, string ns, string name, Enums.AccessType access, params string[] imports)
            {
                //const string indent = "    ", newLine = "\n\r";
                var result = new CSharpClassFileBuilder(indent, newLine)
                    .WithImports(imports.ToList())
                    .WithNamespace(ns).WithName(name)
                    .WithAccess(access)
                    .Build().Generate().ToString();

                var hasNamespace = !string.IsNullOrEmpty(ns);

                var expected = "";

                if (imports.Length > 0)
                {
                    expected = $"using {string.Join($";{newLine}using ", imports)};{newLine}{newLine}";
                }

                var i = 0;

                if (hasNamespace)
                {
                    expected += $"namespace {ns}{newLine}{{{newLine}";
                    expected = Indent(expected, indent, ++i);
                }

                expected += $"{access.AsLowerString()} class {name}{newLine}";
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

            [Theory]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "Program", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\r\n", "\t", "", "MyInterface", Enums.AccessType.Public, "System", "System.Collections.Generic", "System.Linq")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public, "System")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "    ", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public)]
            public void Interface_Test(string newLine, string indent, string ns, string name, Enums.AccessType access, params string[] imports)
            {
                //const string indent = "    ", newLine = "\n\r";
                var result = new CSharpInterfaceFileBuilder(indent, newLine)
                    .WithImports(imports.ToList())
                    .WithNamespace(ns)
                    .WithAccess(access)
                    .WithName(name)
                    .Build();

                var hasNamespace = !string.IsNullOrEmpty(ns);

                var expected = "";

                if (imports.Length > 0)
                {
                    expected += $"using {string.Join($";{newLine}using ", imports)};{newLine}{newLine}";
                }

                var i = 0;

                if (hasNamespace)
                {
                    expected += $"namespace {ns}{newLine}{{{newLine}";
                    expected = Indent(expected, indent, ++i);
                }

                expected += $"{access.AsLowerString()} interface {name}{newLine}";
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
                _output.WriteLine($"{result.FileName}.{result.FileExt}");
                _output.WriteLine($"Expected:\n\n{expected}");
                _output.WriteLine($"Result:\n\n{result.Generate()}");
#endif

                Assert.Equal(expected, result.Generate().ToString());
            }
        }

        public sealed class JavaTest
        {
#if DEBUG
            private readonly ITestOutputHelper _output;

            public JavaTest(ITestOutputHelper output)
            {
                _output = output;
            }
#endif

            [Theory]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "Program", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\r\n", "\t", "", "MyClass", Enums.AccessType.Public, "System", "System.Collections.Generic", "System.Linq")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public, "System")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "    ", "AutoMatedCodeGeneration.CLI", "MyClass", Enums.AccessType.Public)]
            public void Class_Test(string newLine, string indent, string ns, string name, Enums.AccessType access, params string[] imports)
            {
                //const string indent = "    ", newLine = "\n\r";
                var result = new JavaClassFileBuilder(indent, newLine)
                    .WithImports(imports.ToList())
                    .WithNamespace(ns).WithName(name)
                    .WithAccess(access)
                    .Build().Generate().ToString();

                var hasNamespace = !string.IsNullOrEmpty(ns);

                var expected = hasNamespace ? $"package {ns};{newLine}{newLine}" : "";

                if (imports.Length > 0)
                {
                    expected += $"import {string.Join($";{newLine}import ", imports)};{newLine}{newLine}";
                }

                var i = 0;

                expected += $"{access.AsLowerString()} class {name}{newLine}";
                expected = Indent(expected, indent, i);
                expected += $"{{{newLine}";
                expected = Indent(expected, indent, ++i);
                expected += $"{newLine}";
                expected = Indent(expected, indent, --i);
                expected += "}";

#if DEBUG
                _output.WriteLine($"Expected:\n\n{expected}");
                _output.WriteLine($"Result:\n\n{result}");
#endif

                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "Program", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\r\n", "\t", "", "MyInterface", Enums.AccessType.Public, "System", "System.Collections.Generic", "System.Linq")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public, "System")]
            [InlineData("\r\n", "\t", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "\t", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public, "System", "System.Collections.Generic")]
            [InlineData("\n", "    ", "AutoMatedCodeGeneration.CLI", "MyInterface", Enums.AccessType.Public)]
            public void Interface_Test(string newLine, string indent, string ns, string name, Enums.AccessType access, params string[] imports)
            {
                //const string indent = "    ", newLine = "\n\r";
                var result = new JavaInterfaceFileBuilder(indent, newLine)
                    .WithImports(imports.ToList())
                    .WithNamespace(ns)
                    .WithAccess(access)
                    .WithName(name)
                    .Build();

                var hasNamespace = !string.IsNullOrEmpty(ns);

                var expected = hasNamespace ? $"package {ns};{newLine}{newLine}" : "";

                if (imports.Length > 0)
                {
                    expected += $"import {string.Join($";{newLine}import ", imports)};{newLine}{newLine}";
                }

                var i = 0;

                expected += $"{access.AsLowerString()} interface {name}{newLine}";
                expected = Indent(expected, indent, i);
                expected += $"{{{newLine}";
                expected = Indent(expected, indent, ++i);
                expected += $"{newLine}";
                expected = Indent(expected, indent, --i);
                expected += "}";

#if DEBUG
                _output.WriteLine($"{result.FileName}.{result.FileExt}");
                _output.WriteLine($"Expected:\n\n{expected}");
                _output.WriteLine($"Result:\n\n{result.Generate()}");
#endif

                Assert.Equal(expected, result.Generate().ToString());
            }
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