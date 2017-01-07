using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroServiceRepositorys
{
    public interface ICartRepo
    {
        IEnumerable<Cart> Get(int? id);
        void Put(int userId, int giftBoxId, int quantity);
        void Post(int userId, int giftBoxId, int? quantity);
        void Delete(int userId, int? giftBoxId);

        //http://localhost:51359/api/cart/delete?userid=1&giftboxid=2
        //http://localhost:51359/api/Cart/Post?userid=1&giftboxid=4&quantity=6
        //http://localhost:51359/api/Cart/put?userid=1&giftboxid=1&quantity=6
    }
}