using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data.Models
{
    /// <summary>
    /// Блюдо в ресторане
    /// </summary>
    public class Dish
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public string CreationDate { get; }
        [Display(Name = "Название")]
        [StringLength(4)]
        [Required(ErrorMessage = "Длина названия не менее 4 символов")]
        public string Title { get; set; }
        [Display(Name = "Состав")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина состава не менее 1 символа")]
        public string Ingredients { get; set; }
        [Display(Name = "Описание")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина описания не менее 1 символа")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина цены не менее 1 символа")]
        public double Price { get; set; }
        [Display(Name = "Вес")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина веса не менее 1 символа")]
        public int Weight { get; set; }
        [Display(Name = "Калории")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина калорий не менее 1 символа")]
        public int Calories { get; set; }
        [Display(Name = "Время создания")]
        [StringLength(1)]
        [Required(ErrorMessage = "Длина времени создания не менее 1 символа")]
        public int TimeToMake { get; set; }
    }
}
