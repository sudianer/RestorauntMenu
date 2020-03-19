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
        private readonly AppDbContent DbContent;

        public DishRepository(AppDbContent appContent)
        {
            DbContent = appContent;
        }


        public IEnumerable<Dish> Dishes => DbContent.Dish;
        public Dish GetDish(int DishId) => DbContent.Dish.FirstOrDefault(p => p.Id == DishId);
        
    }
}
