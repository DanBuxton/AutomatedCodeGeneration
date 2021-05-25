using System;
using System.Threading.Tasks;
using static System.Console;
using static AutomatedCodeGeneration.Helper;

namespace AutomatedCodeGeneration.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var info = GetInfoFromArgs(args);

            var result = await SystemGenerator.CreateSystem(info);

            WriteLine($"Details:\n\tId:\t\t{info.Id}\n\tLanguage:\t{info.TargetLanguage}\n\tOutput:\t\t{info.Output}");

            WriteLine();

            if (result.HasError)
            {
                GotError(result.Error);
            }
            else
            {
                var color = ForegroundColor;
                ForegroundColor = ConsoleColor.Green;

                WriteLine("Your system has been created");

                ForegroundColor = color;
            }
        }

        private static void GotError(string error)
        {
            var color = ForegroundColor;

            ForegroundColor = ConsoleColor.Red;

            Error.WriteLine(error);

            WriteLine();

            ForegroundColor = color;

            Environment.Exit(-1);
        }
    }
}
