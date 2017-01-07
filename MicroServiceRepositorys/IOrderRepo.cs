using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepositorys
{
    interface IOrderRepo
    {
        IEnumerable<Order> GetOrders(int userId);
    }
}
