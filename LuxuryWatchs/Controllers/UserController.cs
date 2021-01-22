using Bus.ControllerImpl;
using Dao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace LuxuryWatchs.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index(string userID)
        {

            return View();
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(string userID, String password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserBus userBus = new UserBus();
        //        userBus.Login(userID, password);
        //        var user = userBus.GetById(userID);
        //        var userSession = new UserLogin();
        //        userSession.UserID = userID;
        //        userSession.UserName = user.FullName;

        //                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
        //                return RedirectToAction("Profile");
        //        }
        //        return RedirectToAction("Profile");

        //        return RedirectToAction("Index");
        //    }

        //    return View("Index"); 

        //}

       

        public IActionResult Register()
        {
            return View("Register");
        }

        //Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("UserID,FullName,Password,Email,IsAdmin,Status")]UserModel user)
        {
            UserBus userBus = new UserBus();
            userBus.Insert(user);
            return View("Index");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userID, String password)
        {
            
            UserBus userBus = new UserBus();
            if(userBus.Login(userID, password))
            {
                var user = userBus.GetDetailUser(userID);
                ViewBag.Users = user;
                ProductBus productBus = new ProductBus();
                var model = productBus.GetList();
                ViewBag.Products = model;
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:{1}", "txt", DateTime.Now.ToString());
                return View("Index");
            }
            
            
        }
        

    }
}
