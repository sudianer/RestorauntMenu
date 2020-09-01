using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data.Models
{
    /// <summary>
    /// Блюдо в ресторане
    /// </summary>
    public class Dish
    {
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
        [Required(ErrorMessage = "Длина цены не менее 1 символа")]
        public decimal Price { get; set; }

        [Display(Name = "Время приготовления")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Длина времени приготовления не менее 1 символа!")]
        public int TimeToMake { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
