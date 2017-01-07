using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dtos;

namespace MicroServiceRepositorys
{
    public class MockCart : ICartRepo
    {
        IEnumerable<Cart> cart;
        public MockCart()
        {
            cart = CreateCart();
        }

        public IEnumerable<Cart> CreateCart()
        {
            List<Cart> list = new List<Cart>();
            list.Add(new Cart
            {
                CartId = 1,
                UserId = 1,
                GiftBoxId = 5,
                Quantity = 3
            });

            list.Add(new Cart
            {
                CartId = 2,
                UserId = 1,
                GiftBoxId = 3,
                Quantity = 1
            });

            list.Add(new Cart
            {
                CartId = 3,
                UserId = 2,
                GiftBoxId = 1,
                Quantity = 2
            });

            list.Add(new Cart
            {
                CartId = 4,
                UserId = 3,
                GiftBoxId = 3,
                Quantity = 3
            });

            return list;
        }
        
        public void Delete(int userId, int? giftBoxId)
        {
            if (giftBoxId == null)
            {
                IEnumerable<Cart> c = cart.Where(a => a.UserId == userId);
                List<Cart> tempCart = (List<Cart>)c;
                foreach (Cart a in tempCart)
                {
                    tempCart.Remove(a);
                }
                cart = tempCart.AsEnumerable();
            } else
            {
                //Get all carts that we wish to remove from the db.
                List<Cart> tempCart = cart.ToList();
                tempCart.RemoveAll(x => x.UserId == userId & x.GiftBoxId == giftBoxId);
                cart = tempCart.AsEnumerable();
            }
        }

        public IEnumerable<Cart> Get(int? userId)
        {
            if (userId != null)
            {
                return cart.Where(b => b.UserId == userId);
            } else
            {
                return cart;
            }
        }

        public void Post(int userId, int giftBoxId, int? quantity)
        {
            List<Cart> tempCart = (List<Cart>) cart;
            tempCart.Add(new Cart
            {
                UserId = userId,
                GiftBoxId = giftBoxId,
                Quantity = (int)quantity
            });
            cart = tempCart.AsEnumerable();
        }

        public void Put(int userId, int giftBoxId, int quantity)
        {
            Cart c = cart.Where(b => b.UserId == userId & b.GiftBoxId == giftBoxId & b.Quantity == quantity).FirstOrDefault();
        }
    }
}