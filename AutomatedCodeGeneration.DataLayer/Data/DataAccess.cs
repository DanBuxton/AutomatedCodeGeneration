using System;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams;

namespace AutomatedCodeGeneration.DataLayer.Data
{
    public abstract class DataAccess
    {
        private static readonly DataContext Db = new();

        protected static bool DbOk => Db.Database.CanConnect();

        protected static async Task AddModel(SystemModel model)
        {
            if (DbOk)
            {
                await Db.Systems.AddAsync(model);
            }
        }

        protected static async Task<SystemModel> GetSystem(Guid id)
        {
            SystemModel model = null;

            if (DbOk)
            {
                model = await Db.Systems.FindAsync(id);
            }

            return model;
        }
    }
}