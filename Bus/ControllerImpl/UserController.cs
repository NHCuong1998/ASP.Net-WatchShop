using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class UserController : IBaseController<UserModel>
    {
        public List<UserModel> GetList()
        {
            return DataAccess.GetInstance().UserModels.ToList();
        }

        public void Insert(UserModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.UserModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(UserModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.UserModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var _db = DataAccess.GetInstance();
            UserModel model = _db.UserModels.Find(id);

            _db.UserModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            var _db = DataAccess.GetInstance();
            UserModel model = _db.UserModels.Find(id);
            model.Status = status;

            _db.UserModels.Update(model);
            _db.SaveChanges();
        }
    }
}