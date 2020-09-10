using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data
{
    public class AppDbContext: DbContext
    {

        public DbSet<Dish> Dish { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .HasIndex(t => t.Title)
                .IsUnique()
                .HasName("Index_title");

            
        }


       
    }
}
