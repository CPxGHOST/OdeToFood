using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.core;
using OdeToFood.data;

namespace OdeToFood.Pages.Restaraunts
{
    public class ListModel : PageModel
    {
       
        public IEnumerable<Restaurant> Restaurants;
        
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
       
        private readonly IRestaurantData restaurantData;
       
        public ListModel( IRestaurantData restaurantData)
        {           
            this.restaurantData = restaurantData;
        }
        
        public void OnGet()
        {
         this.Restaurants = this.restaurantData.GetRestaurantByName(this.SearchTerm);
        }
    }
}
