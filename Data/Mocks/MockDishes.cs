using RestorauntMenu.Data.Interfaces;
using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data.Mocks
{
    public class MockDishes: IDishes
    {
        public IEnumerable<Dish> Dishes
        {
            get
            {
                return new List<Dish>
                {
                    new Dish {
                        Title = "Carbonara",
                        Price = 300,
                        Ingredients = "pasta, cheese, bacon, eggs",
                        Calories = 400,
                        Description="most popular pasta in our menu",
                        TimeToMake = 10,
                        Weight = 300
                    },

                     new Dish {
                        Title = "Bolognese",
                        Price = 250,
                        Ingredients = "pasta, beef, tomato sauce",
                        Calories = 400,
                        Description="famous italian pasta",
                        TimeToMake = 10,
                        Weight = 350
                    },
                    new Dish {
                        Title = "Fetuchine alfredo",
                        Price = 300,
                        Ingredients = "pasta, cheese, butter",
                        Calories = 400,
                        Description="",
                        TimeToMake = 10,
                        Weight = 300
                    },
                    new Dish {
                        Title = "ribeye steak",
                        Price = 300,
                        Ingredients = "beef, pepper, salt",
                        Calories = 400,
                        Description="",
                        TimeToMake = 10,
                        Weight = 300
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
