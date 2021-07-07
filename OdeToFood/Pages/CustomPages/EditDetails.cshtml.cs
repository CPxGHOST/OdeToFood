using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.CustomPages
{
    public class EditDetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
              
        public EditDetailsModel(IRestaurantData restaurantData , IHtmlHelper htmlHelper) {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId) {

            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();
            this.Restaurant = restaurantData.GetRestarauntById(restaurantId);
            
            if (this.Restaurant == null) {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost() {

            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();

            if (ModelState.IsValid) {
                restaurantData.UpdateRestaurant(Restaurant);
                restaurantData.Commit();
                TempData["Message"] = Restaurant.Name + " Updated!";
                return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
            }

            return Page();
            
        }

    }
}
