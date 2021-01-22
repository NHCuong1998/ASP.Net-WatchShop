using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class ProductBus : IBaseController<ProductModel>
    {
        private readonly DataContext _db = new DataContext();

        public List<ProductModel> GetDetailProduct(Guid id)
        {

            return _db.ProductModels
                            .Where(x => x.Id == id)
                            .OrderBy(x => x.ProductCode)
                            .ToList();

        }

        public List<ProductModel> GetListGender(string gender)
        {
            return _db.ProductModels.Where(x => x.Gender == gender)
                            .OrderBy(x => x.ProductCode)
                            .ToList();
        }

        public List<ProductModel> GetList()
        {
            return _db.ProductModels.ToList();
      
        }
        public List<ProductModel> GetListByTypeId(Guid typeId)
        {
            return _db.ProductModels
                            .Where(x=>x.ProductTypeId == typeId)
                            .OrderBy(x=>x.ProductCode)
                            .ToList();
        }


        public void Insert(ProductModel model)
        {
            _db.ProductModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(ProductModel model)
        {
            _db.ProductModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ProductModel model = _db.ProductModels.Find(id);

            _db.ProductModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            ProductModel model = _db.ProductModels.Find(id);
            model.Status = status;

            _db.ProductModels.Update(model);
            _db.SaveChanges();
        }
    }
}