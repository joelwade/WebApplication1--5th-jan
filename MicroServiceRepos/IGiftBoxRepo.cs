using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepos
{
    public interface IGiftBoxRepo
    {
        IEnumerable<GiftBox> Get(int? id);
        void Post(GiftBox giftBox);
        void Put(GiftBox giftBox);
        void Delete(GiftBox giftBox);
    }
}