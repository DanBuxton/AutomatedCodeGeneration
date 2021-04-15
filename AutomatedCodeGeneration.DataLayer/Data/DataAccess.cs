using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using Microsoft.EntityFrameworkCore;

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
                model = await Db.Systems.Include(x=>x.Classes).FirstOrDefaultAsync(x=>x.Id == id);
            }

            return model;
        }
    }
}