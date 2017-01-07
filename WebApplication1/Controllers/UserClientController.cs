using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MicroServiceRepos;
using Dtos;
using Pages;

namespace WebApplication1.Controllers
{
    public class UserClientController : ApiController
    {
        private readonly IGiftBoxRepo giftRepo;
        private readonly IOrderRepo orderRepo;
        private readonly ICartRepo cartRepo;

        public UserClientController(IGiftBoxRepo giftRepo, IOrderRepo orderRepo, ICartRepo cartRepo)
        {
            this.giftRepo = giftRepo;
            this.orderRepo = orderRepo;
            this.cartRepo = cartRepo;
        }

        /// <summary>
        /// Get Methods
        /// </summary>

        [HttpGet]
        [Route("api/getGiftBox")]
        public IEnumerable<GiftBox> GetGiftBoxes(int? id)
        {
            return giftRepo.Get(id);
        }

        [HttpGet]
        [Route("api/getOrder")]
        public IEnumerable<Order> GetOrders(int? id)
        {
            return orderRepo.Get(id);
        }

        [HttpGet]
        [Route("api/getCart")]
        public IEnumerable<Cart> GetCart(int? id)
        {
            return cartRepo.Get(id);
        }

        [HttpGet]
        [Route("api/getStorePage")]
        public StorePage GetStorePageNoId()
        {
            StorePage page = new StorePage();
            page.giftBoxes = GetGiftBoxes(null);
            return page;
        }

        [HttpGet]
        [Route("api/getStorePage")]
        public StorePage GetStorePage(int? userId)
        {
            StorePage page = new StorePage();
            page.cart = GetCart(userId);
            page.giftBoxes = GetGiftBoxes(null);
            return page;
        }

        [HttpGet]
        [Route("api/getOrderPage")]
        public OrderPage GetOrderPage(int? userId)
        {
            OrderPage page = new OrderPage();
            page.cart = GetCart(userId);
            page.orders = GetOrders(userId);
            return page;
        }

        /// <summary>
        ///  Post Methods
        /// </summary>

        [HttpPost]
        [Route("api/postCart")]
        public HttpResponseMessage PostCart(int userId, int giftBoxId, int quantity)
        {
            cartRepo.Post(userId, giftBoxId, quantity);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/postOrder")]
        public HttpResponseMessage PostOrder(int userId, int giftBoxId, int quantity)
        {
            orderRepo.Post(userId, giftBoxId, quantity);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //http://stackoverflow.com/questions/20226169/how-to-pass-json-post-data-to-web-api-method-as-object

        /// <summary>
        ///  Put Methods
        /// </summary>

        [HttpPut]
        [Route("api/putCart")]
        public HttpResponseMessage PutCart(int cartId, int userId, int giftBoxId, int quantity)
        {
            bool result = cartRepo.Put(cartId, userId, giftBoxId, quantity);

            return CheckResult(result);
        }

        [HttpPut]
        [Route("api/putOrder")]
        public HttpResponseMessage PutOrder(int orderId, int userId, int giftBoxId, int quantity)
        {
            bool result = orderRepo.Put(orderId, userId, giftBoxId, quantity);

            return CheckResult(result);
        }

        /// <summary>
        ///  Delete Methods
        /// </summary>

        [HttpDelete]
        [Route("api/deleteCart")]
        public HttpResponseMessage DeleteCart(int cartId)
        {
            bool result = cartRepo.Delete(cartId);

            return CheckResult(result);
        }

        [HttpDelete]
        [Route("api/deleteOrder")]
        public HttpResponseMessage DeleteOrder(int orderId)
        {
            bool result = orderRepo.Delete(orderId);

            return CheckResult(result);
        }

        private HttpResponseMessage CheckResult(bool res)
        {
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}