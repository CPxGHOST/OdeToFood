using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.CustomPages
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        
        public Restaurant restaurant;

        public DetailsModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public void OnGet(int restaurantId)
        {
            this.restaurant = restaurantData.GetRestarauntById(restaurantId);
        }

    }
}
