using System.Collections.Generic;

namespace RestorauntMenu.Data.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
