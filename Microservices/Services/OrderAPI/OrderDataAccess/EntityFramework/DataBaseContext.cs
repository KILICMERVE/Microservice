using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderDataAccess.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TESODEV;Trusted_Connection=true");
        }
        public DbSet<Order> Orders { get; set; }

    }
}
