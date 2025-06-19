using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetByEmail(string email);
        Customer GetByRefreshToken(string refreshToken);
        Customer CheckLogin(string email, string password);
    }
}
