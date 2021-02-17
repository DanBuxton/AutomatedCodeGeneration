﻿using System.Threading.Tasks;

namespace AutomatedCodeGeneration.Models
{
    public sealed class SystemGenerator
    {
        public static async Task<Result> CreateSystem(SystemInfo systemInfo)
        {
            var systemBuilder = new Internal.SystemBuilder(systemInfo);

            var err = await systemBuilder.CreateSystem();

            return new Result(err?.Message);
        }

        public sealed record Result
        {
            public bool HasError => Error != null;

            public string Error { get; private init; }

            public Result(string error)
            {
                Error = error;
            }

            public void Deconstruct(out string errorMessage) => (errorMessage) = (Error);
        }
    }
}