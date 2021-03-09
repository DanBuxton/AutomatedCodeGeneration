using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Data;
using AutomatedCodeGeneration.DataLayer.Managers;

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
            return await Task.Run(async () =>
            {
                try
                {
                    var db = new DataContext();

                    //PopulateDB(db);

                    var system = await db.Systems.FindAsync(_id);

                    //TODO: Sort this - URGENT
                    system.Classes.AddRange(db.Classes.Where(c=>c.System.Id == system.Id).ToList());

                    //system = db.Systems.Find(_id);

                    //TODO: Create language managers
                    var mgr = Helper.GetLanguageManager(_language, system);

                    if (mgr != null)
                    { 
                        mgr.GenerateFiles();

                        await mgr.OutputFiles(_output);
                    }
#if DEBUG
                    Console.WriteLine($"Language manager: {mgr?.GetType().Name}");
#endif
                }
                catch (Exception e)
                {
#if DEBUG
                    Console.WriteLine($"\n{e.Message}:\n{e.StackTrace}");
#endif

                    return new InvalidOperationException("Sorry, there was an error generating your code!", e);
                }

                return null;
            });

        }
    }
}
