using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.CustomPages
{
    public class AddRestaurantModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines;

        public AddRestaurantModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {
            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();
          
        }

        public IActionResult OnPost() {
            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();
            if (ModelState.IsValid) {
              
                restaurantData.SaveRestaurant(Restaurant);
                restaurantData.Commit();
                TempData["Message"] = Restaurant.Name + " Added!!";
                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}
