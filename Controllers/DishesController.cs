using Microsoft.AspNetCore.Mvc;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.Data.Models;
using RestorauntMenu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Controllers
{
    public class DishesController : Controller
    {
        private readonly IDishes _dishes;

        public DishesController(IDishes dish)
        {
            _dishes = dish;
        }

        public ViewResult List()
        {
            //DishesListViewModel Dvm = new DishesListViewModel()
            //{
            //    AllDishes = _dishes.Dishes
            //};
            
            return View(_dishes.Dishes);
        }
    }
}
