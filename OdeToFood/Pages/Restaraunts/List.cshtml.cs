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
        public String Message { get; set; }
        public IEnumerable<Restaurant> Restaurants;

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        private readonly IConfiguration iconfig;
        private readonly IRestaurantData restaurantData;

        public String Message2 { get; set; }

        public ListModel(IConfiguration configuration , IRestaurantData restaurantData)
        {
            this.iconfig = configuration;
            this.restaurantData = restaurantData;
            
        }
        
        public void OnGet()
        {
               
            Message2 = iconfig["Message"];
            this.Restaurants = this.restaurantData.GetRestaurantByName(this.SearchTerm);
        
        }

       
    }
}
