using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Codecool.CodecoolShop.Helpers;





namespace Codecool.CodecoolShop.Controllers
{




    [Route("cart")]
    public class CartController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity);
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
            Product product = new Product();

            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { Product = product, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }

            else
            {
                List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Cart { Product = product, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }



    }
}
