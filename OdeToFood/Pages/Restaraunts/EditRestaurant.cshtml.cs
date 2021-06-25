using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.core;
using OdeToFood.data;

namespace OdeToFood.Pages.Restaraunts
{
    public class EditRestaurantModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        
        public EditRestaurantModel(IRestaurantData restaurantData , IHtmlHelper htmlHelper) {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restarauntId)
        {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            this.Restaurant = restaurantData.GetRestaurantById(restarauntId);
            
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
           
            return Page();
        }

        public IActionResult OnPost()
        {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (ModelState.IsValid) {
                this.Restaurant = restaurantData.ModifyRestaurant(Restaurant);
                restaurantData.Commit();
                TempData["Message"] = "Restaurant Updated!";
                return RedirectToPage("./Detail" , new { restarauntId = Restaurant.ID});
            }
           
               
                return Page();
           
           
        }

    }
}
