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

        public DishesController(IDishes dishes)
        {
            _dishes = dishes;
        }

        public ViewResult List()
        {
            return View(_dishes.Dishes);
        }
    }
}
