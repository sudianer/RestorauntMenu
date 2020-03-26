using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.ViewModels;

namespace RestorauntMenu.Controllers
{
    public class HomeController: Controller
    {
        private IDishes _dishes;

        public HomeController(IDishes dishes)
        {
            _dishes = dishes;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                dishes = _dishes.Dishes
            };
            return View(_dishes.Dishes);
        }

    }


}
