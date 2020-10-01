using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorauntMenu.Data;
using RestorauntMenu.Data.Models;

namespace RestorauntMenu.Controllers
{
	/// <summary>
	/// Контроллер главной страницы
	/// </summary>
	public class HomeController : Controller
	{
		readonly AppDbContext _db;

		public HomeController(AppDbContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index(string sortOrder, string searchString, int pageNumber = 1, int pageSize = 5)
		{
			var dishes = from s in _db.Dish
						 select s;

			ViewData["totalCount_dishes"] = dishes.Count();
			ViewData["CurrentFilter"] = searchString;

			if (!String.IsNullOrEmpty(searchString))
			{
				dishes = dishes.Where(s => s.Title.Contains(searchString)
										|| s.Ingredients.Contains(searchString)
										|| s.Description.Contains(searchString)
										|| s.Id.ToString().Contains(searchString)
										|| s.Price.ToString().Contains(searchString)
										|| s.CreationDate.ToString().Contains(searchString)
										|| s.TimeToMake.ToString().Contains(searchString));
			}

			dishes = sortOrder switch
			{
				"title_desc" => dishes.OrderByDescending(p => p.Title),
				"title" => dishes.OrderBy(p => p.Title),
				"date_desc" => dishes.OrderByDescending(p => p.CreationDate),
				"date" => dishes.OrderBy(p => p.CreationDate),
				"cost_desc" => dishes.OrderByDescending(p => p.CreationDate),
				"cost" => dishes.OrderBy(p => p.CreationDate),
				"id_desc" => dishes.OrderByDescending(p => p.Id),
				"id" => dishes.OrderBy(p => p.Id),
				"weight_desc" => dishes.OrderByDescending(p => p.Id),
				"weight" => dishes.OrderBy(p => p.Id),
				"calories_desc" => dishes.OrderByDescending(p => p.Id),
				"calories" => dishes.OrderBy(p => p.Id),
				"timeToMake_desc" => dishes.OrderByDescending(p => p.Id),
				"timeToMake" => dishes.OrderBy(p => p.Id),
				_ => dishes.OrderBy(p => p.Title),
			};

			var count = await dishes.CountAsync();
			IEnumerable<Dish> dishesPerPage = await dishes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
			PageViewModel pageViewModel = new PageViewModel(count, pageNumber, pageSize);
			IndexViewModel viewModel = new IndexViewModel
			{
				PageViewModel = pageViewModel,
				dishes = dishesPerPage
			};

			return View(viewModel);
		}

		/// <summary>
		/// Возвращает вьюшку создания нового блюда
		/// </summary>
		public IActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// Обновляет бд, добавляя новое блюдо
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> Create(Dish dish)
		{
			if (!IsTitleUnique(dish.Title, _db.Dish.ToList())) 
			{
				ModelState.AddModelError("Title", "Такое имя уже существует");
				return View();
			}

			dish.CreationDate = DateTime.Now;

			_db.Dish.Attach(dish);
			_db.Dish.Add(dish);
			await _db.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Показывает форму с подробной информацией о блюде
		/// </summary>
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return NotFound();
			
			Dish dish = await _db.Dish.FirstOrDefaultAsync(p => p.Id == id);

			if (dish == null)
				return View();

			return View(dish);
		}
		[HttpPost]
		public async Task<IActionResult> Details()
		{
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Показывает форму редактирования объекта
		/// </summary>
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();
			
			Dish dish = await _db.Dish.FirstOrDefaultAsync(p => p.Id == id);
			
			if (dish == null)
				return View();

			return View(dish);
		}

		/// <summary>
		/// обновляет объект в базе данных
		/// </summary>
		/// <param name="dish"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Edit(Dish dish)
		{
			List<Dish> dishes = _db.Dish.AsNoTracking().ToList();

			if (!(IsTitleUnique(dish.Title, dishes) || IsTitleNotChanged(dish.Title, dish.Id, dishes)))
			{
				ModelState.AddModelError("Title", "Такое имя уже существует");

				return RedirectToAction("Index");
			}

			_db.Dish.Update(dish);
			await _db.SaveChangesAsync();

			return View(dish);
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
			if (id == null)
				return NotFound();

			Dish dish = await _db.Dish.FirstOrDefaultAsync(p => p.Id == id);

			_db.Entry(dish).State = EntityState.Deleted;
			await _db.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Проверяет уникальность введенного названия
		/// </summary>
		/// <param name="title">Проверяемое название</param>
		private bool IsTitleUnique(string title, List<Dish> dishes)
		{
			foreach (Dish dish in dishes)
			{
				if (dish.Title.Trim().ToLower() == title.Trim().ToLower())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Проверяет, изменилялось ли название
		/// </summary>
		private bool IsTitleNotChanged(string title, int id, List<Dish> dishes)
		{
			foreach (Dish dish in dishes)
			{
				if (dish.Id == id && dish.Title.Trim().ToLower() == title.Trim().ToLower())
				{
					return true;
				}
			}

			return false;
		}
	}




}
