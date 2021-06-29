using OdeToFood.core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData() {
            this.restaurants = new List<Restaurant>
            {
                new Restaurant{Name = "Momo Villa" , ID = 1 , Location = "New Delhi" , Cuisine = CuisineType.Italian },
                new Restaurant{Name = "Taco Bells" , ID = 3 , Location = "Mumbai" , Cuisine = CuisineType.Mexican},
                new Restaurant{Name = "Pind Balluchi" , ID = 2 , Location = "Chandigarh" , Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null) {


           return restaurants.FindAll(r => name == null || r.Name.StartsWith(name)).OrderBy(r => r.Name);

        
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

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            this.restaurants.OrderBy(r => r.ID);

            newRestaurant.ID = this.restaurants[restaurants.Count - 1].ID + 1;

            this.restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            
            Restaurant removedRestaurant = this.restaurants.SingleOrDefault(r => r.ID == id);
            int index =  restaurants.IndexOf(removedRestaurant);
           
            if (index != -1) {
                this.restaurants.RemoveAt(index);
            }

            return removedRestaurant;
        }
    }   



}
