using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Dish> dishes { get; set; }
    }
}
