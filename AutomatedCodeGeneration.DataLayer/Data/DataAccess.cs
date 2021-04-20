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

        protected static Task<SystemModel> GetSystem(Guid id)
        {
            Task<SystemModel> model = null;

            if (DbOk)
            {
                model = Db.Systems.Include(x=>x.Classes).FirstOrDefaultAsync(x=>x.Id == id && !x.BeenGenerated);
            }

            return model;
        }
    }
}