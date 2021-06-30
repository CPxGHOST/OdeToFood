using Microsoft.EntityFrameworkCore;
using OdeToFood.core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext context) {
            this.context = context;
        }

        public int Commit()
        {
            return this.context.SaveChanges();
            
        }

        public int CountAllRestaurants()
        {
            return this.context.Restaurants.Count();
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            this.context.Restaurants.Add(restaurant);
            return restaurant;
           
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);

            this.context.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return this.context.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in context.Restaurants
                        where name == null || r.Name == name
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant ModifyRestaurant(Restaurant newRestaurant)
        {
            var entity = this.context.Attach(newRestaurant);
            entity.State = EntityState.Modified;
            return newRestaurant;
        }
    }


}
