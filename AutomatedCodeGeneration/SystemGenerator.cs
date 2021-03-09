using System;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer;

namespace AutomatedCodeGeneration
{
    public sealed class SystemGenerator
    {
        public static async Task<Result> CreateSystem(SystemInfo systemInfo)
        {
#if DEBUG
            System.Diagnostics.Stopwatch sw = new();
            sw.Start();
#endif

            var systemBuilder = new SystemBuilder(systemInfo);

            var result = await systemBuilder.CreateSystem();

#if DEBUG
            sw.Stop();

            Console.WriteLine($"Completed in: {sw.Elapsed.TotalMilliseconds}ms");
#endif

            return new Result((result as InvalidOperationException)?.Message);
        }

        public sealed record Result
        {
            public bool HasError => Error != null;

            public string Error { get; }

            public Result(string error)
            {
                Error = error;
            }

            public void Deconstruct(out string errorMessage) => (errorMessage) = (Error);
        }
    }
}
