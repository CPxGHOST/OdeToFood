using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlData : IRestaurantData
    {
        private readonly OdeToFoobDbContext db;

        public SqlData(OdeToFoobDbContext db) {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public int CountRestaurants()
        {
            return db.Restaurants.Count();
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestarauntById(id);
            
            if (restaurant != null) {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetRestarauntById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaraunts(string term)
        {
            var restaurants = from r in db.Restaurants
                              where term == null || r.Name.StartsWith(term)
                              orderby r.Name
                              select r;

            return restaurants;
        }

        public Restaurant SaveRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
