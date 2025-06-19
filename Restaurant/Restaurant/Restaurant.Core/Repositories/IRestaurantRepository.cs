using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IRestaurantRepository : IEntity<Restaurant.Core.Entities.Restaurant>
    {
        Task<List<Restaurant.Core.Entities.Restaurant>> GetPagination(int page = 1, int pageSize = 3);
    }
}
