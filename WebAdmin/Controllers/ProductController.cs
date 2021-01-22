using Bus.ControllerImpl;
using Dao.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class ProductController : Controller
    {
        
        public IActionResult Index()
        {
            ProductBus productBus = new ProductBus();
            var model = productBus.GetList();
            ViewBag.Products = model;
            return View();

        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete(Guid id)
        {
            ProductBus productBus = new ProductBus();
            var model = productBus.GetDetailProduct(id);
            ViewBag.Products = model;
            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductBus productBus = new ProductBus();
            var model = productBus.GetDetailProduct(id);
            ViewBag.Products = model;
            return View();
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            ProductBus productBus = new ProductBus();
            var model = productBus.GetDetailProduct(id);
            ViewBag.Products = model;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,ProductCode,Model,ProductName,ProductTypeId,CaseSize,CaseMaterial,Crystal,WaterResistance,Function,WatchMovement,Price,Quantity,About,")] ProductModel product)
        {
            ProductBus productBus = new ProductBus();
            productBus.Update(product);
            var model = productBus.GetList();
            ViewBag.Products = model;
            return View("Index");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ProductCode,Model,ProductName,ProductTypeId,CaseSize,CaseMaterial,Crystal,WaterResistance,Function,WatchMovement,Price,Quantity,About,")] ProductModel product)
        //{
        //    ProductBus productBus = new ProductBus();
        //    productBus.Insert(product);
        //    var model = productBus.GetList();
        //    ViewBag.Products = model;
        //    return View("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            ProductBus productBus = new ProductBus();
            productBus.Delete(id);
            var model = productBus.GetList();
            ViewBag.Products = model;
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                var product = new ProductModel
                {
                    Id = new Guid(),
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    Model = model.Model,
                    ProductTypeId = model.ProductTypeId,
                    CaseSize = model.CaseSize,
                    CaseMaterial = model.CaseMaterial,
                    Gender = model.Gender,
                    WaterResistance = model.WaterResistance,
                    Function = model.Function,
                    WatchMovement = model.WatchMovement,
                    BranchId = model.BranchId,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    ProductImage = uniqueFileName,
                    DateNew = DateTime.Now
                };
                ProductBus productBus = new ProductBus();
                productBus.Insert(product);
            }
            return View();
        }

        private string UploadedFile(ProductModel model)
        {
            string uniqueFileName = null;

            if (model.ProductImage != null)
            {
                //string uploadsFolder = "wwwroot/libAdmin/images";

                //uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                //string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    model.ProductImage.CopyTo(fileStream);


                //}
            }

            return uniqueFileName;
        }

      

    }
}
