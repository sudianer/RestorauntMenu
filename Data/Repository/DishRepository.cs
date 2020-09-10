using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data.Repository
{
    public class DishRepository : IDishes
    {
        private readonly AppDbContext AppDbContent;

        public DishRepository(AppDbContext appContent)
        {
            AppDbContent = appContent;
        }

        public IEnumerable<Dish> Dishes => AppDbContent.Dish;
        public Dish GetDish(int DishId) => AppDbContent.Dish.FirstOrDefault(p => p.Id == DishId);
    }
}
