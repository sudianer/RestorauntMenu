using System.Collections.Generic;

namespace RestorauntMenu.Data.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Dish> dishes { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
