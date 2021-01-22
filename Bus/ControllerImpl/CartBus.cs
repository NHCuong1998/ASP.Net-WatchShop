using Bus.IController;
using Dao;
using Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bus.ControllerImpl
{
    public class CartBus : IBaseController<CartModel>
    {
        private readonly DataContext _db = new DataContext();
        public void Delete(Guid id)
        {
            CartModel model = _db.CartModels.Find(id);
            _db.CartModels.Remove(model);
            _db.SaveChanges();

        }
       
        public List<CartModel> GetList(string id)
        {
            return _db.CartModels
                            .Where(x =>x.UserID == id)
                            .OrderBy(x => x.ProductID)
                            .ToList();
        }

        public List<CartModel> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(CartModel model)
        {
            _db.CartModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(CartModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            throw new NotImplementedException();
        }

        


    }
}
