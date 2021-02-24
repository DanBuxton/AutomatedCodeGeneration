using System;
using System.Threading.Tasks;

namespace AutomatedCodeGeneration.DataLayer
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
                    var model = new DataContext().Systems.Find(_id);

                    //TODO: Create file models and language managers
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
