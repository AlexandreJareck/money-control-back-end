using Microsoft.EntityFrameworkCore;
using MoneyControl.Business.Models;

namespace MoneyControl.Data.Context
{
    public class MoneyControlDbContext : DbContext
    {
        public MoneyControlDbContext(DbContextOptions<MoneyControlDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction>  Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetMaxLength(250);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoneyControlDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
