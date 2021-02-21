using System;
using System.Threading.Tasks;
using AutomatedCodeGeneration.Library;

namespace AutomatedCodeGeneration.Models
{
    public sealed class SystemGenerator
    {
        public static async Task<Result> CreateSystem(SystemInfo systemInfo)
        {
            var systemBuilder = new SystemBuilder(systemInfo);

            var result = await systemBuilder.CreateSystem();

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
