using OdeToFood.core;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.data
{
    public interface IRestaurantData
    {
        //public IEnumerable<Restaurant> GetAll();

        public IEnumerable<Restaurant> GetRestaurantByName(string name);

        public Restaurant GetRestaurantById(int id);

        public Restaurant ModifyRestaurant(Restaurant newRestaurant);

        public Restaurant CreateRestaurant(Restaurant restaurant);

        public Restaurant DeleteRestaurant(int id);

        public int CountAllRestaurants();

        public int Commit();
            
    }


}
