using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required , MaxLength(30) , MinLength(4)]
        public string Name { get; set; }

        public Cuisine CuisineType { get; set; }

        [Required]
        public string Location { get; set; }
    }
}