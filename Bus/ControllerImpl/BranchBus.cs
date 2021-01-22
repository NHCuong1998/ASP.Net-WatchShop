using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bus.IController;
using Dao;
using Dao.Models;

namespace Bus.ControllerImpl
{
    public class BranchBus : IBaseController<BranchModel>
    {
        private readonly DataContext _db = new DataContext();

        public List<BranchModel> GetList()
        {
            return _db.BranchModels.ToList();
        }

        public void Insert(BranchModel model)
        {
            _db.BranchModels.Add(model);
            _db.SaveChanges();
        }

        public void Update(BranchModel model)
        {
            _db.BranchModels.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            BranchModel model = _db.BranchModels.Find(id);
            _db.BranchModels.Remove(model);
            _db.SaveChanges();
        }

        public void UpdateStatus(Guid id, bool status)
        {
            BranchModel model = _db.BranchModels.Find(id);
            model.Status = status;

            _db.BranchModels.Update(model);
            _db.SaveChanges();
        }
    }
}