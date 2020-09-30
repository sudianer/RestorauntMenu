using System;
using System.Collections.Generic;
using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.Data.Models;

namespace RestorauntMenu.Data.Mocks
{
    public class MockDishes : IDishes
    {
        public IEnumerable<Dish> Dishes
        {
            get
            {
                return new List<Dish>
                {      
                   
                };
            }
        }

        public Dish GetDish(int DishId)
        {
            throw new NotImplementedException();
        }

        public Dish AddDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
