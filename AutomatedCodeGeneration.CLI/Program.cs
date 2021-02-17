using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using AutomatedCodeGeneration.Models;
using static System.Console;

var systemId = Guid.Parse("aef3af89-f90a-4670-bcb0-ff7693325faa");
var outputPath = "";
var language = "";
var previousFlag = "";
#if DEBUG
args = new[]
{
    "-id",
    "aef3af89-f90a-4670-bcb0-ff7693325faa",
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
                string path = a.Replace('-', ' ');
                if (!Directory.Exists(path))
                {
                    errors.Add($"Invalid path: {path}");
                }
                else
                {
                    outputPath = path;
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

var info = Helper.CreateSystemInfo(systemId, language);

var result = SystemGenerator.CreateSystem(info);

do
{
    Clear();

    await System.Threading.Tasks.Task.Run(() =>
    {
        WriteLine($"Details:\n\tId:\t\t{info.Id}\n\tLanguage:\t{info.TargetLanguage}\n\tOutput:\t\t{""/*info.Output*/}");

        WriteLine();
        WriteLine($"Your system is being created");

        Write("\nPlease wait");
        for (int i = 0; i < 3 && !result.IsCompleted; i++)
        {
            Thread.Sleep(500);

            Write(" .");

            Thread.Sleep(1000);
        }
    });

} while (!result.IsCompleted);

Clear();

static void GotError(params string[] errors)
{
    var color = ForegroundColor;

    ForegroundColor = ConsoleColor.Red;

    foreach (var e in errors)
        Error.WriteLine(e);

    ForegroundColor = color;

    Environment.Exit(-1);
}