using System;
using System.Collections.Generic;
using Dao.Models;

namespace Bus.IController
{
    public interface IUserController
    {
        //public List<UserModel> GetList();

        //public void Insert(UserModel model);

        //public void Update(UserModel model);

        //public void UpdateStatus(string id, bool status);

        //public void Delete(string id);

        public bool Login(String user, String password);
    }
}
