using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class ProductTypeModelController : IBaseController<ProductTypeModel>
    {
        public List<ProductTypeModel> GetList()
        {
            return DataAccess.GetInstance().ProductTypeModels.ToList();
        }

        public void Insert(ProductTypeModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.ProductTypeModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(ProductTypeModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.ProductTypeModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var _db = DataAccess.GetInstance();
            ProductTypeModel model = _db.ProductTypeModels.Find(id);

            _db.ProductTypeModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            var _db = DataAccess.GetInstance();
            ProductTypeModel model = _db.ProductTypeModels.Find(id);
            model.Status = status;

            _db.ProductTypeModels.Update(model);
            _db.SaveChanges();
        }
    }
}