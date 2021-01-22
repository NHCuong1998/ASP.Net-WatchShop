using Bus.IController;
using Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Bus.ControllerImpl
{
    class CartController : IBaseController<CartModel>
    {
        public void Delete(Guid id)
        {
            var _db = DataAccess.GetInstance();
            CartModel model = _db.CartModels.Find(id);

            _db.CartModels.Remove(model);
            _db.SaveChanges();
        }

        public List<CartModel> GetList()
        {
            return DataAccess.GetInstance().CartModels.ToList();
        }

        public void Insert(CartModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.CartModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(CartModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.CartModels.Update(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            var _db = DataAccess.GetInstance();
            CartModel model = _db.CartModels.Find(id);
            model.Status = status;

            _db.CartModels.Update(model);
            _db.SaveChanges();
        }
    }
}
