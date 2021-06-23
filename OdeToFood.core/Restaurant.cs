using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.core
{

    public class Restaurant
    {
        public String Location { get; set; }

        public String Name { get; set; }

        public int ID { get; set; }

        public CuisineType Cuisine { get; set; }

    }
}
