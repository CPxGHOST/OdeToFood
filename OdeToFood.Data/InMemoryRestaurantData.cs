using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> Restaurants;

        public InMemoryRestaurantData() {
            Restaurants = new List<Restaurant>() {
                    new Restaurant{Name = "Momo Villa" , Location="New Delhi" , Id = 1 , CuisineType = Cuisine.Chinese },
                    new Restaurant{Name = "Burger King" , Location = "Saket" , Id= 2 , CuisineType = Cuisine.American }

                };
                
        }

        public int Commit()
        {
            return 0;
        }

        public int CountRestaurants()
        {
            return Restaurants.Count;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestarauntById(id);

            if (restaurant != null) {
                Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetRestarauntById(int id)
        {
            var restaurant = Restaurants.Find(r => r.Id == id);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaraunts(string term)
        {
            var query = from r in Restaurants
                        where term == null || r.Name.StartsWith(term)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant SaveRestaurant(Restaurant restaurant)
        {
            restaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var oldRestaurant = GetRestarauntById(updatedRestaurant.Id);

            if (oldRestaurant != null) {
                oldRestaurant.Name = updatedRestaurant.Name;
                oldRestaurant.Location = updatedRestaurant.Location;
                oldRestaurant.CuisineType = updatedRestaurant.CuisineType;
            }

            return updatedRestaurant;
        }
    }
}
