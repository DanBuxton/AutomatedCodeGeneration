using AutomatedCodeGeneration.Library.Data.Diagrams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutomatedCodeGeneration.Library.Data
{
    internal sealed class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<SystemModel> Systems { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_config?.GetConnectionString("ACG") ?? "Data Source=.\\sqlexpress;Initial Catalog=AutomatedCodeGeneration;Integrated Security=True");

            base.OnConfiguring(options);
        }
    }
}