using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer;

namespace AutomatedCodeGeneration;

public abstract record SystemGenerator
{
    //Force no instances
    private SystemGenerator() { }

    public static async Task<Result> CreateSystem(SystemInfo systemInfo, CancellationToken cancellationToken = default)
    {
        try
        {
            //Generate and output the system
            var result = await SystemBuilder.CreateSystem(systemInfo, cancellationToken);
            
            //Either error message or null
            return new Result(result?.Message);
        }
        catch (Exception)
        {
            return new Result("Sorry, there was an error generating your code!");
        }
    }

    public sealed record Result
    {
        public bool HasError => Error != null;

        public string Error { get; }

        public Result(string error = null)
        {
            Error = error;
        }

        public void Deconstruct(out string errorMessage) => (errorMessage) = (Error);
    }
}
