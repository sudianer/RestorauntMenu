using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.ViewModels
{
    public class DishesListViewModel
    {
        public IEnumerable<Dish> AllDishes { get; set; }      
    }
}
