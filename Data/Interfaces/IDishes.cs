using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestorauntMenu.Data.Models;

namespace RestorauntMenu.Data.Interfaces
{
    public interface IDishes
    {

        /// <summary>
        /// Возвращает все блюда в списке
        /// </summary>
        public IEnumerable<Dish> Dishes { get; }
        /// <summary>
        /// возвращает одно блюдо по Id
        /// </summary>
        /// <param name="DishId">Id искомого блюда</param>
        /// <returns></returns>
        Dish GetDish(int DishId);
    }
}
