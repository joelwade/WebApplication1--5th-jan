using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class GiftBox
    {
        public int id { get; set; }
        public IEnumerable<Product> products { get; set; }
        public Wrapping wrapping { get; set; }
        public int price { get; set; }
    }
}