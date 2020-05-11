using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Accounting_for_finance.Models
{
    class ApplicationContext : DbContext
    {
        private string databaseName;

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Category> Categoryes { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public ApplicationContext(string databasePath = "database.db")
        {
            databaseName = databasePath;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath =
              Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
