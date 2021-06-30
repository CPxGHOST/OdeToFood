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
    public class DeleteRestaurantModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty]
        public Restaurant restaurant { get; set; }

        public DeleteRestaurantModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restarauntId)
        {
            this.restaurant = restaurantData.GetRestaurantById(restarauntId);

            if (this.restaurant != null) {
               
                return Page();
            }

            return RedirectToPage("./NotFound");
        }

        public IActionResult OnPost(int restarauntId) {

            var deletedRestaurant =  this.restaurantData.DeleteRestaurant(restarauntId);

            if (deletedRestaurant != null) {
                this.restaurantData.Commit();
                TempData["Message"] = $"{deletedRestaurant.Name} Deleted!!";
                return RedirectToPage("./List");
            }

            return RedirectToPage("./NotFound");

        }
    
    }
}
