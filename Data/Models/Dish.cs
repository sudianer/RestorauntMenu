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
        [Display(Name = "Название")]
        [StringLength(40)]
        [Required(ErrorMessage = "Длина названия не менее 4 символов")]
        
        public string Title { get; set; }
        [Display(Name = "Состав")]
        [StringLength(120)]
        [Required(ErrorMessage = "Длина состава не менее 1 символа")]
        public string Ingredients { get; set; }
        [Display(Name = "Описание")]
        [StringLength(100)]
        [Required(ErrorMessage = "Длина описания не менее 1 символа")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        [DataType(DataType.Currency, ErrorMessage = "Must be a Decimal!")]
        [Required(ErrorMessage = "Длина цены не менее 1 символа")]
        public decimal Price { get; set; }
        [Display(Name = "Время приготовления")]
        [MinLength(1)]
        [Required(ErrorMessage = "Длина времени приготовления не менее 1 символа!")]
        public int TimeToMake { get; set; }


    }
}
