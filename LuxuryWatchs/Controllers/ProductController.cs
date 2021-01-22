using Bus.ControllerImpl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string Id, string UserID)
        {
            ProductBus productBus = new ProductBus();
            if (Id == null)
            {
                var model = productBus.GetList();
                ViewBag.Products = model;
            }
            else
            {
                Guid g = new Guid(Id);
                var model = productBus.GetListByTypeId(g);
                ViewBag.Products = model;
            }
            
            
            
            return View();
        }

        public IActionResult IndexListGender(string gender, string UserID)
        {
            if (UserID == "" || UserID == null)
            {
            }
            else
            {
                UserBus userBus = new UserBus();
                var user = userBus.GetDetailUser(UserID);
                ViewBag.Users = user;
            }

            ProductBus productBus = new ProductBus();
            var model = productBus.GetListGender(gender);
            ViewBag.Products = model;
            return View("Index");
        }

        public IActionResult DetailProduct(Guid id,string UserID)
        {
            if (UserID == "" || UserID == null)
            {
            }
            else
            {
                UserBus userBus = new UserBus();
                var user = userBus.GetDetailUser(UserID);
                ViewBag.Users = user;
            }
            Guid typeId = id;
            if (id == null)
            {
                return NotFound();
            }
            ProductBus productBus = new ProductBus();
            var model = productBus.GetDetailProduct(id);
            ViewBag.Products = model;
            foreach(var item in ViewBag.Products)
            {
                typeId = item.ProductTypeId;
            }
            ProductTypeModelBus productTypeModelBus = new ProductTypeModelBus();
            var modelType = productTypeModelBus.GetProductType(typeId);
            ViewBag.ProductType = modelType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ListProductType(Guid typeId)
        {
            ProductBus productBus = new ProductBus();
            var model = productBus.GetListByTypeId(typeId);
            ViewBag.Products = model;
            return View("Index");
        }



    }
}
