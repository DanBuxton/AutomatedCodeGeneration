using AutomatedCodeGeneration.DataLayer.Diagrams;
using AutomatedCodeGeneration.DataLayer.Diagrams.ClassDiagram;
using Microsoft.EntityFrameworkCore;

namespace AutomatedCodeGeneration.DataLayer.Data
{
    public sealed class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString = null)
        {
            _connectionString = connectionString ?? "Data Source=localhost,11433;Initial Catalog=AutomatedCodeGeneration;User Id=sa;Password=Asdfgh123!";
        }

        public DbSet<SystemModel> Systems { get; set; }
        public DbSet<UseCaseModel> UseCases { get; set; }
        public DbSet<ClassModel> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);

            base.OnConfiguring(options);
        }
    }
}