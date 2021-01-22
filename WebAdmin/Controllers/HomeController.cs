using Bus.ControllerImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string UserID, string Password)
        {
            UserBus userBus = new UserBus();
           
            if (userBus.LoginAdmin(UserID, Password))
            {
                var user = userBus.GetDetailUser(UserID);
                ViewBag.Users = user;
                ProductBus productBus = new ProductBus();
                var model = productBus.GetList();
                ViewBag.Products = model;
                return View("Index");
            }
            else
            {
                ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:{1}", "txt", DateTime.Now.ToString());
                return View("Login");
            }

        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
