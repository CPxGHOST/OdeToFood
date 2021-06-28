﻿using Microsoft.EntityFrameworkCore;
using OdeToFood.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.data
{
   public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        { 
        
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}