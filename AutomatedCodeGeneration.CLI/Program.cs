using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer;
using static System.Console;
using static AutomatedCodeGeneration.Models.Helper;

namespace AutomatedCodeGeneration.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var info = GetInfoFromArgs(args);

            var result = SystemGenerator.CreateSystem(info);

            do
            {
#if RELEASE
                Console.Clear();
#endif

                await Task.Run(() =>
                {
                    WriteLine($"Details:\n\tId:\t\t{info.Id}\n\tLanguage:\t{info.TargetLanguage}\n\tOutput:\t\t{info.Output}");

                    WriteLine();
                    WriteLine("Your system is being created");

                    Write("\nPlease wait");
                    for (var i = 0; i < 3 && !result.IsCompleted; i++)
                    {
                        Thread.Sleep(1000);

                        switch (result.Status)
                        {
                            case TaskStatus.Created:
                            case TaskStatus.WaitingForActivation:
                            case TaskStatus.WaitingToRun:
                            case TaskStatus.Running:
                            case TaskStatus.WaitingForChildrenToComplete:
                            case TaskStatus.RanToCompletion:
                                break;
                            case TaskStatus.Canceled:
                            case TaskStatus.Faulted:
                                result.Result.Error = "The request was cancelled";
                                break;
                        }

                        Write(" .");
                    }
                    Thread.Sleep(1000);
                });

            } while (!result.IsCompleted);

#if RELEASE
            Console.Clear();
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

        private static SystemInfo GetInfoFromArgs(IEnumerable<string> args)
        {
            //var systemId = Guid.Parse("aef3af89-f90a-4670-bcb0-ff7693325faa");
            var systemId = Guid.Parse("234e024d-d03f-4158-0fb9-08d8e15373c5");
            string output = null, language = "CSharp", previousFlag = null;
#if DEBUG
            args = new[]
            {
                "-id",
                "234e024d-d03f-4158-0fb9-08d8e15373c5",
                "-path",
                @"C:\Temp\ACG\",
                "-lang",
                "CSharp"
            };
#endif

            var errors = new List<string>();

            foreach (var a in args)
            {
                if (a[0].Equals('-'))
                {
                    previousFlag = a[1..].ToLower();
                }
                else
                {
                    var arg = a.ToLower();

                    switch (previousFlag) // Search for flags
                    {
                        case "outpath":
                        case "output":
                        case "outdir":
                        case "result":
                        case "path":
                            var path = a.Replace('-', ' ');
                            if (Directory.Exists(path) || a[0..6].ToLower().Equals("github "))
                            {
                                output = path;
                            }
                            else
                            {
                                errors.Add($"Invalid path: {path}");
                            }

                            break;
                        case "systemid":
                        case "system":
                        case "id":
                            if (!Guid.TryParse(arg, out systemId))
                            {
                                errors.Add($"Invalid id: {a}");
                            }

                            break;
                        case "language":
                        case "lang":
                            var l = LanguageExists(arg);
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

            return CreateSystemInfo(systemId, language, output);
        }

        private static void GotError(params string[] errors)
        {
            var color = ForegroundColor;

            ForegroundColor = ConsoleColor.Red;

            foreach (var e in errors) Error.WriteLine(e);

            WriteLine();

            ForegroundColor = color;

            Environment.Exit(-1);
        }
    }
}
