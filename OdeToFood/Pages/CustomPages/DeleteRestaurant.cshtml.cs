using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.CustomPages
{
    public class DeleteRestaurantModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteRestaurantModel(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)

        {
            Restaurant = restaurantData.GetRestarauntById(restaurantId);
           
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantId) {

            Restaurant = restaurantData.GetRestarauntById(restaurantId);
            var tempRestaurant =  restaurantData.DeleteRestaurant(Restaurant.Id);
            restaurantData.Commit();

            if (tempRestaurant == null) {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = "Deleted " + Restaurant.Name +" Successfully!!";
            return RedirectToPage("./List");
        
        }
      

    }
}
