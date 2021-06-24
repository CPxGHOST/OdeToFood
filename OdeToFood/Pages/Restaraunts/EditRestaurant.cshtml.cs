using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.core;
using OdeToFood.data;

namespace OdeToFood.Pages.Restaraunts
{
    public class EditRestaurantModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant restaurant;

        public EditRestaurantModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public void OnGet(int restarauntId)
        {
            restaurant = restaurantData.GetRestaurantById(restarauntId);
        }

        
    }
}
