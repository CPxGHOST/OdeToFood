using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetRestaraunts(string term);

        public Restaurant GetRestarauntById(int id);

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant);

        public int Commit();

        public Restaurant SaveRestaurant(Restaurant restaurant);

        public Restaurant DeleteRestaurant(int id);
        
        public int CountRestaurants();
    
    }
}
