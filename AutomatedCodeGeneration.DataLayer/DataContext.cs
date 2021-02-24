using AutomatedCodeGeneration.DataLayer.Diagrams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutomatedCodeGeneration.DataLayer
{
    public sealed class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString = null)
        {
            _connectionString = connectionString;
        }
        public DbSet<SystemModel> Systems { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString ?? "Data Source=.\\sqlexpress;Initial Catalog=AutomatedCodeGeneration;Integrated Security=True");

            base.OnConfiguring(options);
        }
    }
}