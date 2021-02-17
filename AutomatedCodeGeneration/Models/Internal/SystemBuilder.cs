using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedCodeGeneration.Models.Internal
{
    internal class SystemBuilder
    {
        private readonly Guid _id;
        private readonly string _language;
        private readonly string output;

        public SystemBuilder(SystemInfo systemInfo)
        {
            (_id, _language, output) = systemInfo;
        }

        public async Task<InvalidOperationException> CreateSystem()
        {
            return await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(10000);
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
