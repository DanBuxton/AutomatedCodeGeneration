using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.Library.Data;
using AutomatedCodeGeneration.Library.Data.Diagrams;
using AutomatedCodeGeneration.Library.Data.Diagrams.ClassDiagram;

namespace AutomatedCodeGeneration.Library
{
    public sealed class SystemBuilder
    {
        private readonly Guid _id;
        private readonly string _language;
        private readonly string _output;

        public SystemBuilder(SystemInfo systemInfo)
        {
            (_id, _language, _output) = systemInfo;
        }

        public async Task<object> CreateSystem()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var model = new DataContext(null).Systems.Find(_id);
                }
                catch (Exception e)
                {
                    return new InvalidOperationException(e.Message, e);
                }

                return null;
            });

        }
    }
}
