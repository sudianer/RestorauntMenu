﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestorauntMenu.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntMenu.Data
{
    public class DbObject
    {
        public static void Initial(IApplicationBuilder app) 
        {
            AppDbContent DbContent = app.ApplicationServices.GetRequiredService<AppDbContent>();
                
            

        }
    }
}
