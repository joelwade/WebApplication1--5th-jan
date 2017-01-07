using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepositorys
{
    class MockOrder : IOrderRepo
    {
        List<Order> orders = new List<Order>();

        public MockOrder()
        {
            orders.Add(new Order
            {
                orderId = 1
            });
        }
        public IEnumerable<Order> GetOrders(int userId)
        {
            return orders;
        }
    }
}
