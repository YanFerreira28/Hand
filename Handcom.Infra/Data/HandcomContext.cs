using Handcom.Domain.Entities;
using Handcom.Infra.Config;
using Microsoft.EntityFrameworkCore;

namespace Handcom.Infra.Data
{
    public class HandcomContext : DbContext
    {
        public HandcomContext() {  }

        public DbSet<Users> User { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryBuilder).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupplierBuilder).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserBuilder).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductBuilder).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SessionBuilder).Assembly);

        }
    }
}
