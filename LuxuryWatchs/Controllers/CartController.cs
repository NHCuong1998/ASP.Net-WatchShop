using Bus.ControllerImpl;
using Dao.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxuryWatchs.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return View("~/Views/User/Index.cshtml");
            }
            CartBus cartBus = new CartBus();
            var model = cartBus.GetList(id);
            ViewBag.Products = model;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CartModel cart, string UserID)
        {
            if(UserID == null || UserID == "")
            {
                //return View("~/Views/User/Index.cshtml");
                return RedirectToAction("Index", "User");
            }
            else
            {
                CartBus cartBus = new CartBus();
                cartBus.Insert(cart);
                var model = cartBus.GetList(UserID);
                ViewBag.Carts = model;
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCart(Guid id, string UserID)
        {
            CartBus cartBus = new CartBus();
            cartBus.Delete(id);
            var model = cartBus.GetList(UserID);
            ViewBag.Carts = model;
            UserBus userBus = new UserBus();
            var user = userBus.GetDetailUser(UserID);
            ViewBag.Users = user;
            return View("Index");
        }
    }
}
