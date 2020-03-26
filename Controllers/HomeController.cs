using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.ViewModels;
using RestorauntMenu.Data;

namespace RestorauntMenu.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class HomeController: Controller
    {
        private IDishes _dishes;
        AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;        
        }

        public ViewResult Index()
        {
            return View(_db.Dish.ToList());
        }

    }


}
