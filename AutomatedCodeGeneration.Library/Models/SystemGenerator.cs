using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCodeGeneration.Library.Models
{
    public sealed class SystemGenerator
    {
        public static async Task<Result> CreateSystem(dynamic systemInfo)
        {
            await Task.Run(() =>
            {
                //TODO: Generate the system
            });

            throw new NotImplementedException();
        }

        public sealed record Result
        {
            public bool HasError { get => Errors != null; }

            public string[] Errors { get; private init; } = null;

            public Result(string[] errors)
            {
                Errors = errors;
            }

            public void Deconstruct(out string[] errorMsgs) => (errorMsgs) = (Errors);
        }
    }
}
