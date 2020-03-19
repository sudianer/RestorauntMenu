using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data
{
    public class AppDbContent: DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options): base(options)
        {
        }

        public DbSet<Dish> Dish { get; set; }
    }
}
