using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.Models;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace AutomatedCodeGeneration.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var systemId = Guid.Parse("aef3af89-f90a-4670-bcb0-ff7693325faa");
            var systemId = Guid.Empty;
            string output = null, language = null, previousFlag = null;
#if DEBUG
            args = new[]
            {
                "-id",
                "89f323d1-8e74-4be6-ba5c-08d8dfe7e014",
                "-path",
                @"C:\Temp\ACG\",
                "-lang",
                "cSharp"
            };
#endif

            var errors = new List<string>();

            foreach (var a in args)
            {
                if (a.StartsWith('-'))
                {
                    previousFlag = a.ToLower();
                }
                else
                {
                    var arg = a.ToLower();

                    switch (previousFlag.ToLower()) // Search for flags
                    {
                        case "-outpath":
                        case "-output":
                        case "-outdir":
                        case "-result":
                        case "-path":
                            var path = a.Replace('-', ' ');
                            if (Directory.Exists(path) || a.ToLower().StartsWith("github"))
                            {
                                output = path;
                            }
                            else
                            {
                                errors.Add($"Invalid path: {path}");
                            }
                            break;
                        case "-systemid":
                        case "-system":
                        case "-id":
                            if (!Guid.TryParse(arg, out systemId))
                            {
                                errors.Add($"Invalid id: {a}");
                            }
                            break;
                        case "-language":
                        case "-lang":
                            var l = Helper.LanguageExists(arg);
                            if (l.HasValue)
                            {
                                language = arg;
                            }
                            else
                            {
                                errors.Add($"Invalid language: {a}");
                            }
                            break;
                        default:
                            errors.Add($"Invalid flag: '{previousFlag}'");
                            break;
                    }

                    previousFlag = "";
                }
            }

            if (errors.Count > 0)
            {
                GotError(errors.ToArray());
            }

            var info = Helper.CreateSystemInfo(systemId, language, output ?? Directory.GetCurrentDirectory());

            var result = SystemGenerator.CreateSystem(info);

            do
            {
#if RELEASE
                Clear();
#endif

                await Task.Run(() =>
                {
                    WriteLine($"Details:\n\tId:\t\t{info.Id}\n\tLanguage:\t{info.TargetLanguage}\n\tOutput:\t\t{info.Output}");

                    WriteLine();
                    WriteLine("Your system is being created");

                    Write("\nPlease wait");
                    for (int i = 0; i < 3 && !result.IsCompleted; i++)
                    {
                        Thread.Sleep(1000);

                        Write(" .");
                    }
                    Thread.Sleep(1000);
                });

            } while (!result.IsCompleted);

#if RELEASE
                Clear();
#endif

            WriteLine($"Details:\n\tId:\t\t{info.Id}\n\tLanguage:\t{info.TargetLanguage}\n\tOutput:\t\t{info.Output}");

            WriteLine();

            if (result.Result.HasError)
            {
                GotError(result.Result.Error);
            }
            else
            {
                var color = ForegroundColor;
                ForegroundColor = ConsoleColor.Green;

                WriteLine("Your system has been created");

                ForegroundColor = color;
            }
        }
        private static void GotError(params string[] errors)
        {
            var color = ForegroundColor;

            ForegroundColor = ConsoleColor.Red;

            foreach (var e in errors)
                Error.WriteLine(e);

            ForegroundColor = color;

            Environment.Exit(-1);
        }
    }
}
