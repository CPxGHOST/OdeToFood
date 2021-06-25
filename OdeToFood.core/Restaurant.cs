using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.core
{

    public class Restaurant
    {
        [Required , MaxLength(250) , MinLength(4)]
        public String Location { get; set; }

        [Required , MinLength(5) , MaxLength(25)]
        public String Name { get; set; }

        public int ID { get; set; }

        [Required]
        public CuisineType Cuisine { get; set; }

    }
}
