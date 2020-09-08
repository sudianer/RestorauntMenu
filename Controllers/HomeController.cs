using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.Data;
using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var dishes = from s in _db.Dish
                           select s;

            ViewData["totalCount_dishes"] = dishes.Count();

            if (!String.IsNullOrEmpty(searchString)) 
            {
                dishes = dishes.Where(s => s.Title.Contains(searchString)
                                       || s.Ingredients.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.Id.ToString().Contains(searchString)
                                       || s.Price.ToString().Contains(searchString)
                                       || s.CreationDate.ToString().Contains(searchString)
                                       || s.TimeToMake.ToString().Contains(searchString) );
            }

            switch (sortOrder)
            {
                case "title_desc":
                    dishes = dishes.OrderByDescending(p => p.Title);
                    break;
                case "title":
                    dishes = dishes.OrderBy(p => p.Title);
                    break;

                case "date_desc":
                    dishes = dishes.OrderByDescending(p => p.CreationDate);
                    break;
                case "date":
                    dishes = dishes.OrderBy(p => p.CreationDate);
                    break;

                case "cost_desc":
                    dishes = dishes.OrderByDescending(p => p.CreationDate);
                    break;
                case "cost":
                    dishes = dishes.OrderBy(p => p.CreationDate);
                    break;

                case "id_desc":
                    dishes = dishes.OrderByDescending(p => p.Id);
                    break;
                case "id":
                    dishes = dishes.OrderBy(p => p.Id);
                    break;

                case "weight_desc":
                    dishes = dishes.OrderByDescending(p => p.Id);
                    break;
                case "weight":
                    dishes = dishes.OrderBy(p => p.Id);
                    break;

                case "calories_desc":
                    dishes = dishes.OrderByDescending(p => p.Id);
                    break;
                case "calories":
                    dishes = dishes.OrderBy(p => p.Id);
                    break;

                case "timeToMake_desc":
                    dishes = dishes.OrderByDescending(p => p.Id);
                    break;
                case "timeToMake":
                    dishes = dishes.OrderBy(p => p.Id);
                    break;

                default:
                    dishes = dishes.OrderBy(p => p.Title);
                    break;
            }

            return View(dishes);
        }

        //TODO: Валидация ввода при создании/изменении
        //TODO: Проверка уникальности названия
        //TODO: Нормальная работа с БД
        /// <summary>
        /// Возвращает вьюшку создания нового блюда
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Обновляет бд, добавляя новое блюдо
        /// </summary>
        /// <param name="Dish"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Dish Dish)
        {
            Dish.CreationDate = DateTime.Now;
            _db.Dish.Attach(Dish);
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
        [HttpPost]
        public async Task<IActionResult> Details()
        {
            return RedirectToAction("Index");
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
                {                   
                    return View(dish); //при передаче блюда в метод EditDish, сбрасывается дата-время
                }
            }
            return NotFound();
        }

        /// <summary>
        /// обновляет объект в базе данных
        /// </summary>
        /// <param name="dish"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditDish(Dish dish)
        {
            DateTime date = dish.CreationDate;
            _db.Dish.Update(dish);         
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Удаляет блюдо
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ActionName("Delete")]
        [HttpGet]
        public async Task<IActionResult> DeleteDish(int? id)
        {
            if (id != null)
            {
                Dish dish = await _db.Dish.FirstOrDefaultAsync(p => p.Id == id);
                _db.Entry(dish).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        } 


        /// <summary>
        /// Проверяет уникальность введенного названия
        /// </summary>
        /// <param name="title">Проверяемое название</param>
        /// <returns></returns>
        public async Task<IActionResult> IsTitleUnique(string title, string prevAction,string nextAction)
        {
            foreach(Dish dish in _db.Dish.ToList())
            {
                if (dish.Title == title)
                {
                    return RedirectToAction(prevAction);
                }
            }
            return RedirectToAction(nextAction);
        }
    }




}
