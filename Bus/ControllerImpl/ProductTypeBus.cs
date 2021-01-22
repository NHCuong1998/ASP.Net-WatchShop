using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class ProductTypeModelBus : IBaseController<ProductTypeModel>
    {
        private readonly DataContext _db = new DataContext();

        public List<ProductTypeModel> GetList()
        {
            return _db.ProductTypeModels.ToList();
        }

        public List<ProductTypeModel> GetProductType(Guid Id)
        {
            return _db.ProductTypeModels
                            .Where(x=>x.Id == Id)
                            .OrderBy(x=>x.TypeCode)
                            .ToList();
        }
       
        public void Insert(ProductTypeModel model)
        {
            _db.ProductTypeModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(ProductTypeModel model)
        {
            _db.ProductTypeModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ProductTypeModel model = _db.ProductTypeModels.Find(id);

            _db.ProductTypeModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            ProductTypeModel model = _db.ProductTypeModels.Find(id);
            model.Status = status;

            _db.ProductTypeModels.Update(model);
            _db.SaveChanges();
        }
    }
}