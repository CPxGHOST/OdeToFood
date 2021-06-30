using Microsoft.AspNetCore.Mvc;
using OdeToFood.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestarauntCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestarauntCountViewComponent(IRestaurantData restaurantData) {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()    {
            int count = restaurantData.CountAllRestaurants();

            return View(count);
        
        }
    }
}
