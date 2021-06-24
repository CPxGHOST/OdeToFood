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
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public int RestrauntId { get; set; }

        public DetailModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restarauntId)
        {
            this.Restaurant = restaurantData.GetRestaurantById(restarauntId);
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
