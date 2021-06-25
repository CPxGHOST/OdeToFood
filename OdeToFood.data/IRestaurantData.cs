using OdeToFood.core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public int Commit();
            
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData() {
            this.restaurants = new List<Restaurant>
            {
                new Restaurant{Name = "Momo Villa" , ID = 1 , Location = "New Delhi" , Cuisine = CuisineType.Italian },
                new Restaurant{Name = "Pind Balluchi" , ID = 2 , Location = "Chandigarh" , Cuisine = CuisineType.Indian },
                new Restaurant{Name = "Taco Bells" , ID = 3 , Location = "Mumbai" , Cuisine = CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null) { 
            
            return from r in this.restaurants
                   where String.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }

        public Restaurant GetRestaurantById(int id) {

            return this.restaurants.SingleOrDefault(r => r.ID == id);
        
        }

       

        public Restaurant ModifyRestaurant(Restaurant newRestaurant)
        {
            var oldRestaurant = this.restaurants.SingleOrDefault(r => r.ID == newRestaurant.ID);
            if (oldRestaurant != null) {
                oldRestaurant.Name = newRestaurant.Name;
                oldRestaurant.Cuisine = newRestaurant.Cuisine;
                oldRestaurant.Location = newRestaurant.Location;
            
            }
            return oldRestaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }   



}
