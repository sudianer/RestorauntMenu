using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RestorauntMenu.Data.Models
{
    /// <summary>
    /// Блюдо в ресторане
    /// </summary>
    public class Dish
    {
        public int Id { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }


        [Display(Name = "Название")]
        [StringLength(255)]
        [Required(ErrorMessage = "Длина названия не менее 4 символов")]
        public string Title { get; set; }

        [Display(Name = "Состав")]
        public string Ingredients { get; set; }

        [Display(Name = "Описание")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        [Range(1, 100000000)]
        [Required(ErrorMessage = "Цена не может быть 0")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Граммовка")]
        [Range(1,int.MaxValue)]
        [Required(ErrorMessage = "Время приготовления не может быть 0")]
        public int Weight { get; set; }

        [Display(Name = "Калорийность")]
        [Range(1, 100000000)]
        [Required(ErrorMessage = "Время приготовления не может быть 0")]
        public decimal Calories { get; set; }

        [Display(Name = "Время приготовления")]
        [Range(1, int.MaxValue)]
        [Required(ErrorMessage = "Время приготовления не может быть 0")]
        public int TimeToMake { get; set; }


        

       
    }
}
