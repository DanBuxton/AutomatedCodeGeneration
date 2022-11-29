using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutomatedCodeGeneration.DataLayer;

namespace AutomatedCodeGeneration;

public class Helper
{
    public static Enums.Languages? LanguageExists(string lang) => DataLayer.Helper.GetLanguage(lang);

    public static SystemInfo CreateSystemInfo(Guid id, string language, string output) => new(id, language, output);

    public static SystemInfo GetInfoFromArgs(IEnumerable<string> args)
    {
        //var systemId = Guid.Parse("aef3af89-f90a-4670-bcb0-ff7693325faa");
        var systemId = Guid.Parse("234e024d-d03f-4158-0fb9-08d8e15373c5");
        string output = "github::605677c2e4e8d1dfa625", language = "CSharp", previousFlag = null;
#if DEBUG
        args = new[]
        {
            "-id",
            "0a866869-1bc1-4ac6-c627-08d91fb3b958", // 21189b61-44e8-444c-16f8-08d91fb46754 (Dependency)
                                                    // 0a866869-1bc1-4ac6-c627-08d91fb3b958 (Inheritance)
                                                    // 21189b61-44e8-444c-16f8-08d91fb46754 (DirectedAssociation)
            "-path",
            //@"D:\Temp\ACG\",
            "github::170f7e53f12a4d7a65e9",
            "-lang",
            "csharp"
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
                        if (a[..8].Equals("github::"))
                        {
                            output = a;
                        }
                        else if (Directory.Exists(path))
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
            throw new InvalidOperationException(errors.ElementAt(0));
        }

        return CreateSystemInfo(systemId, language, output);
    }
}
