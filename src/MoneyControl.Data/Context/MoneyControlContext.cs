﻿using Microsoft.EntityFrameworkCore;
using MoneyControl.Business.Models;

namespace MoneyControl.Data.Context
{
    public class MoneyControlContext : DbContext
    {
        public MoneyControlContext(DbContextOptions<MoneyControlContext> options) : base(options)
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
