using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Bus.Utils;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class UserBus : IBaseController<UserModel>, IUserController
    {
        private readonly DataContext _db = new DataContext();

        public List<UserModel> GetList()
        {
            return _db.UserModels.ToList();
        }

        public UserModel GetById(string userId)
        {
            return _db.UserModels.SingleOrDefault(x => x.UserID == userId);
        }

        public List<UserModel> GetDetailUser(string UserId)
        {
            
            if (CheckExist(UserId))
            {
                return _db.UserModels.Where(x => x.UserID == UserId).ToList();
            }
            else
            {
                var erorMessage = String.Format("User [{0}] not is exist!", UserId);
                throw new Exception(erorMessage);
            }
            
        }

        public void Insert(UserModel model)
        {
            if (CheckExist(model.UserID))
            {
                var erorMessage = String.Format("User [{0}] is exist!", model.UserID);
                throw new Exception(erorMessage);
            }

            model.Password = Sha256Util.Encrypt(model.Password);

            _db.UserModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(UserModel model)
        {
            string x = model.UserID;
            if (!CheckExist(model.UserID))
            {
                var erorMessage = String.Format("User [{0}] is not exist!", model.UserID);
                throw new Exception(erorMessage);
            }

            _db.UserModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            UserModel user = _db.UserModels.Find(id);

            _db.UserModels.Remove(user);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            UserModel model = _db.UserModels.Find(id);
            model.Status = status;

            _db.UserModels.Update(model);
            _db.SaveChanges();
        }

        private bool CheckExist(String userID)
        {
            var count = _db.UserModels.Where(x => x.UserID == userID).Count();
          
            return count > 0;
        }

        public bool Login(string user, string password)
        {
            var hashedPassword = Sha256Util.Encrypt(password);
            var count = _db.UserModels.Where(x => x.UserID == user && x.Password == hashedPassword && x.Status == true).Count();

            return count > 0;
        }

        public bool LoginAdmin(string user, string password)
        {
            var hashedPassword = Sha256Util.Encrypt(password);
            var count = _db.UserModels.Where(x => x.UserID == user && x.Password == hashedPassword && x.Status == true && x.IsAdmin==true).Count();

            return count > 0;
        }

        public void UpdateStatusUser(string id, bool status)
        {
            UserModel model = _db.UserModels.Find(id);
            model.Status = status;

            _db.UserModels.Update(model);
            _db.SaveChanges();
        }
    }
}