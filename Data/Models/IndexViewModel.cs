﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Dish> dishes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
