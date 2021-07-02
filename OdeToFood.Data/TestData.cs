using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class TestData : IRestaurantData
    {
        List<Restaurant> restaraunts;

        public TestData() { 
          this.restaraunts = new List<Restaurant>() {
           new Restaurant{
                Id = 1,
                Name = "Burger King",
                Location = "New Delhi",
                CuisineType = Cuisine.American
                },
                new Restaurant{
                Id = 2,
                Name = "Dominoes",
                Location = "New Delhi",
                CuisineType = Cuisine.Italian
                },
                new Restaurant{
                Id = 3,
                Name = "Momo Villa",
                Location = "New Delhi",
                CuisineType = Cuisine.Chinese
                }

            };
       }

        public Restaurant GetRestarauntById(int id)
        {
            return this.restaraunts.Find(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaraunts(string term = null)
        {

            var query = from r in this.restaraunts
                        where term == null || r.Name == term
                        select r;

            return query;
        }
    }


}
