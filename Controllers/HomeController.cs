using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.ViewModels;
using RestorauntMenu.Data;
using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data.Models;

namespace RestorauntMenu.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class HomeController: Controller
    {      
        AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;        
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Dish.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Dish Dish)
        {
            _db.Dish.Add(Dish);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Показывает форму с подробной информацией о блюде
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if(id != null)
            {
                Dish dish = await _db.Dish.FirstOrDefaultAsync(p=> p.Id == id);
                if(dish != null)
                    return View(dish);
                
            }
            return NotFound();
        }
        
        /// <summary>
        /// Показывает форму редактирования объекта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Dish dish = await _db.Dish.FirstOrDefaultAsync(p => p.Id == id);
                if (dish != null)
                    return View(dish);
            }
            return NotFound();
        }

        /// <summary>
        /// обновляет объект в базе данных
        /// </summary>
        /// <param name="dish"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Dish dish)
        {
            _db.Dish.Update(dish);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    
    
    
    }




}
