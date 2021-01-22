using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class ProductController : IBaseController<ProductModel>
    {
        public List<ProductModel> GetList()
        {
            return DataAccess.GetInstance().ProductModels.ToList();
        }

        public void Insert(ProductModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.ProductModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(ProductModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.ProductModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var _db = DataAccess.GetInstance();
            ProductModel model = _db.ProductModels.Find(id);

            _db.ProductModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            var _db = DataAccess.GetInstance();
            ProductModel model = _db.ProductModels.Find(id);
            model.Status = status;

            _db.ProductModels.Update(model);
            _db.SaveChanges();
        }
    }
}