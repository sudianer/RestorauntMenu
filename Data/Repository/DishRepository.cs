﻿using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContent AppDbContent;

        public DishRepository(AppDbContent appContent)
        {
            AppDbContent = appContent;
        }


        public IEnumerable<Dish> Dishes => AppDbContent.Dish;
        public Dish GetDish(int DishId) => AppDbContent.Dish.FirstOrDefault(p => p.Id == DishId);

        public Dish AddDish(Dish dish)
        {
            throw new NotImplementedException();
        }  
    }
}
