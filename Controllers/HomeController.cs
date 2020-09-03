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

        public async Task<IActionResult> Index(string sortOrder)
        {           
            var dishes = from s in _db.Dish
                           select s;
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

        //TODO: При сохранении изменений, меняется и дата создания на 01.01.0001, время так же сбрасывается в 00:00
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
        /// Вызывает вьюшку удаления
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if(id != null)
            {
                Dish dish = await _db.Dish.FirstOrDefaultAsync(p => p.Id == id);
                if (dish != null)
                    return View(dish);
            }
            return NotFound();
        }

        /// <summary>
        /// находит и удаляет блюдо из базы данных по id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
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
    
    
    }




}
