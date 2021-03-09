using System.Collections.Generic;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Files;
using AutomatedCodeGeneration.DataLayer.Files.Builders;
using AutomatedCodeGeneration.DataLayer.Managers;
using Xunit;
using Xunit.Abstractions;

namespace AutomatedCodeGeneration.DataLayer.Tests
{
    public sealed class ManagerTests
    {
        private readonly ITestOutputHelper _output;

        public ManagerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CSharp_Test()
        {
            SystemModel system = new() { Namespace = "ACG" };
            List<ClassModel> classes = new()
            {
                new ClassModel()
                {
                    Methods = new List<ClassMethodModel>()
                    {
                        new() {NameType = new NameTypeModel() { Name = "SayHello", Type = "string"}}
                    },
                    Data = new List<ClassDataModel>()
                    {

                    },
                    Namespace = "",
                    Access = AccessType.Internal,
                    Name = "ExampleClass",
                    System = system,
                }
            };
            system.Classes = classes;

            var manager = Helper.GetLanguageManager("CshArp", system);

            Assert.NotNull(manager);
            Assert.True(manager is CSharpManager);
        }
    }
}