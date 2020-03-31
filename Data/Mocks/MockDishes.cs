using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    new Dish {
                        Title = "Carbonara",
                        Ingredients = "pasta, cheese, bacon, eggs",
                        Description="most popular pasta in our menu",                      
                    },

                    
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
