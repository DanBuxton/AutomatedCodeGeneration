using System;
using System.Threading.Tasks;
using AutomatedCodeGeneration.DataLayer.Diagrams;
using Microsoft.EntityFrameworkCore;

namespace AutomatedCodeGeneration.DataLayer.Data;

public abstract class DataAccess
{
    private static readonly DataContext Db = new();
    
    protected static bool DbOk => Db.Database.CanConnect();

    protected static async Task<SystemModel> GetSystem(Guid id)
    {
        SystemModel model = null;

        if (DbOk)
        {
            await Db.SaveChangesAsync();

            model = await Db.Systems
                .Include(x => x.Classes).ThenInclude(x => x.Relations)

                .Include(x => x.Classes)
                    .ThenInclude(x => x.Data).ThenInclude(x=>x.NameType)

                .Include(x => x.Classes)
                    .ThenInclude(x => x.Methods).ThenInclude(x => x.NameType)

                .Include(x => x.Classes)
                    .ThenInclude(x => x.Methods).ThenInclude(x => x.Params)
                
                .FirstOrDefaultAsync(x => x.Id == id && !x.BeenGenerated);
        }

        return model;
    }

    protected static async Task MarkSystemAsGenerated(Guid id)
    {
        Db.Entry(await Db.Systems.FindAsync(id)).Entity.BeenGenerated = true;

        await Db.SaveChangesAsync();
    }

    protected static async Task<SystemModel> AddSystem(SystemModel model)
    {
        if (DbOk)
        {
            var result = await Db.Systems.AddAsync(model);
            await Db.SaveChangesAsync();
            return result.Entity;
        }

        return null;
    }
}