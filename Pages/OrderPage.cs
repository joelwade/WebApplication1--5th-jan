using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace Pages
{
    public class OrderPage
    {
        public IEnumerable<Cart> cart { get; set; }
        public IEnumerable<Order> orders { get; set; }
    }
}
