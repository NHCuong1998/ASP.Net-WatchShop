using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class BranchController : IBaseController<BranchModel>
    {
        public List<BranchModel> GetList()
        {
            return DataAccess.GetInstance().BranchModels.ToList();
        }

        public void Insert(BranchModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.BranchModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(BranchModel model)
        {
            var _db = DataAccess.GetInstance();
            _db.BranchModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var _db = DataAccess.GetInstance();
            BranchModel model = _db.BranchModels.Find(id);

            _db.BranchModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            var _db = DataAccess.GetInstance();
            BranchModel model = _db.BranchModels.Find(id);
            model.Status = status;

            _db.BranchModels.Update(model);
            _db.SaveChanges();
        }
    }
}