using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OdeToFood.core;
using OdeToFood.data;

namespace OdeToFood.Pages.Restaraunts
{
    public class CreateRestaurantModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> Cuisines;
        [BindProperty]
        public Restaurant Restaurant{ get; set; }

        public CreateRestaurantModel(IRestaurantData restaurantData , IHtmlHelper htmlHelper) {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
        }

        public IActionResult OnPost() {
            this.Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (ModelState.IsValid) {
                restaurantData.CreateRestaurant(Restaurant);
                restaurantData.Commit();
                TempData["Message"] = "Restaurant Created!";
                return RedirectToPage("./Detail" , new {restarauntId = Restaurant.ID});
            }

            return Page();
        }
    
    }
}
