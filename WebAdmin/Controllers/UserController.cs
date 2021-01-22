using Bus.ControllerImpl;
using Dao.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {

            UserBus userBus = new UserBus();
            var model = userBus.GetList();
            ViewBag.userBus = model;
            return View();
        }
        public async Task<IActionResult> Create()
        {
            UserBus userBus = new UserBus();
            var model = userBus.GetList();
            ViewBag.userBus = model;
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserBus userBus = new UserBus();
            var model = userBus.GetDetailUser(id);
            ViewBag.userBus = model;
            return View();
        }

        public async Task<IActionResult> Edit(string userID)
        {
            UserBus userBus = new UserBus();
            var model = userBus.GetDetailUser(userID);
            ViewBag.userBus = model;
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            UserBus userBus = new UserBus();
            var model = userBus.GetDetailUser(id);
            ViewBag.userBus = model;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UserID,FullName,Password,Email,IsAdmin,Status")] UserModel user)
        {
            string x = user.FullName;
            UserBus userBus = new UserBus();
            userBus.Update(user);
            var model = userBus.GetList();
            ViewBag.userBus = model;
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            UserBus userBus = new UserBus();
            userBus.UpdateStatusUser(id, false);
            var model = userBus.GetList();
            ViewBag.userBus = model;
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FullName,Password,Email,IsAdmin,Status")] UserModel user)
        {
            UserBus userBus = new UserBus();
            user.IsAdmin = false;
            user.Status = true;
            userBus.Insert(user);
            var model = userBus.GetList();
            ViewBag.userBus = model;
            return View("Index");
        }

    }
}
