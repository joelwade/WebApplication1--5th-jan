using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepositorys
{
    public class CompositeMockRepo : ICartRepo, IOrderRepo, IInventRepo, IGiftboxRepo
    {
        public void Delete(int userId, int? giftBoxId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> orders(int userId)
        {
            throw new NotImplementedException();
        }

        public void Post(int userId, int giftBoxId, int? quantity)
        {
            throw new NotImplementedException();
        }

        public void Put(int userId, int giftBoxId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
