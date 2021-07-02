using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core
{
    public class Restaraunt
    {
     
        public int Id { get; set;}

        public string Name { get; set; }

        public Cuisine CuisineType { get; set; }

        public string Location { get; set; }

    }
}
