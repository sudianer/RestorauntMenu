using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestorauntMenu.Data.Models;

namespace RestorauntMenu.Data.Interfaces
{
    public interface IDishes
    {
        public IEnumerable<Dish> Dishes { get; }
        Dish GetDish(int DishId);
    }
}
