using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using AutomatedCodeGeneration.DataLayer.Managers;
using Xunit;
using Xunit.Abstractions;
using static Xunit.Assert;

namespace AutomatedCodeGeneration.DataLayer.Tests
{
    public sealed class ManagerTests
    {
        [Theory]
        [InlineData("csharp")]
        //[InlineData("java")]
        //[InlineData("python")]
        public void Manager_Exists_Test(string language)
        {
            var manager = Helper.GetLanguageManager(language, GetSystem());

            NotNull(manager);
        }

        private static SystemModel GetSystem()
        {
            SystemModel system = new() { Namespace = "ACG" };
            List<ClassModel> classes = new()
            {
                new ClassModel
                {
                    Methods = new List<ClassMethodModel>
                    {
                        new()
                        {
                            NameType = new NameTypeModel {Name = "Main", Type = "void", IsStatic = true},
                            Params = new List<NameTypeModel>
                            {
                                new() {Name = "args", Type = "string[]"}
                            },
                            Access = AccessType.Public
                        },

                        new() {NameType = new NameTypeModel {Name = "SayHello", Type = "string", IsStatic = true}}
                    },
                    Namespace = "ACG.CLI",
                    Access = AccessType.Internal,
                    Name = "ExampleClass",
                    System = system
                }
            };
            system.Classes = classes;

            return system;
        }

        [Theory]
        [InlineData("brainfuck")]
        public void Manager_Not_Exists_Test(string language)
        {
            Null(Helper.GetLanguageManager(language, GetSystem()));
        }

        [Fact]
        public void CSharp_Test()
        {
            var manager = new CSharpManager(GetSystem());

            Equal(typeof(CSharpManager), manager.GetType());
        }
    }
}