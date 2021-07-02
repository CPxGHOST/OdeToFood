using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetRestaraunts(string term);

        public Restaurant GetRestarauntById(int id);
    
    }


}
