using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Data;
using AutomatedCodeGeneration.DataLayer.Files.Builders;

namespace AutomatedCodeGeneration.DataLayer
{
    public sealed class SystemBuilder// : DbManager
    {
        private readonly Guid _id;
        private readonly string _language;
        private readonly string _output;

        public SystemBuilder(SystemInfo systemInfo)
        {
            (_id, _language, _output) = systemInfo;
        }

        public async Task<object> CreateSystem()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var db = new DataContext();
                    //var system = new SystemModel { Namespace = "ACG" };
                    //db.Systems.Add(system);
                    //db.SaveChanges();

                    //List<ClassModel> classes = new()
                    //{
                    //    new ClassModel
                    //    {
                    //        Access = AccessType.Public,
                    //        Name = "TestClass",
                    //        System = system,
                    //        Namespace = "ACG.BO"
                    //    }
                    //};
                    //db.Classes.AddRange(classes);
                    //db.SaveChanges();

                    //system.Classes = classes;
                    //db.Systems.Update(system);
                    //db.SaveChanges();

                    var system = db.Systems.Find(_id);
                    system.Classes = db.Classes.ToList();
                    db.SaveChanges();

                    system = db.Systems.Find(_id);

                    //TODO: Create file models and language managers
                    var result = new string[system.Classes.Count];

                    for (var i = 0; i < result.Length; i++)
                    {
                        var c = system.Classes.ElementAt(i);

                        CSharpFileBuilder builder = new();
                        builder.WithImports(new List<string> {"System", "System.Collections.Generic"});
                        builder.WithNamespace(c.Namespace);
                        builder.WithClassAccess(c.Access);
                        builder.WithClassName(c.Name);

                        result[i] = builder.Build();

                        var path = $"{_output}\\{c.Name}.cs";

                        if (File.Exists(path)) continue;

                        File.AppendAllText(path, result[i]);

                        Console.WriteLine($"\"{result[i]}\"");
                    }

                    //foreach (var c in system.Classes)
                    //{
                    //    IBuilder builder = new CSharpFileBuilder("    ")
                    //        .WithImports(new List<string> {"System", "System.Collections.Generic"})
                    //        .WithNamespace(system.Namespace)
                    //        .WithClassAccess(c.Access.ToString())
                    //        .WithClassName(c.Name);

                    //    result += $"\n\n{builder.Build()}\n\n---------------------------";
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}:\n{e.StackTrace}");

                    return new InvalidOperationException("Sorry, there was an error generating your code!", e);
                }

                return null;
            });

        }
    }
}
