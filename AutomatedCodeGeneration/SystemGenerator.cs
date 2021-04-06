using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer;

namespace AutomatedCodeGeneration
{
    public sealed record SystemGenerator
    {
        public static async Task<Result> CreateSystem(SystemInfo systemInfo, CancellationToken cancellationToken = default)
        {
#if DEBUG
            System.Diagnostics.Stopwatch sw = new();
            sw.Start();
#endif

            var systemBuilder = new SystemBuilder(systemInfo);

            var result = await systemBuilder.CreateSystem(cancellationToken);

#if DEBUG
            sw.Stop();

            Console.WriteLine($"Completed in: {sw.Elapsed.TotalMilliseconds}ms");
#endif

            return new Result((result as Exception)?.Message);
        }

        public sealed record Result
        {
            public bool HasError => Error != null;

            public string Error { get; set; }

            public Result(string error = null)
            {
                Error = error;
            }

            public void Deconstruct(out string errorMessage) => (errorMessage) = (Error);
        }
    }
}
