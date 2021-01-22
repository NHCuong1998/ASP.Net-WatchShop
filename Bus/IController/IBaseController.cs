using System;
using System.Collections;
using System.Collections.Generic;

namespace Bus.IController
{
    public interface IBaseController<T>
    {
        public List<T> GetList();

        public void Insert(T model);

        public void Update(T model);

        public void UpdateStatus(Guid id, bool status);

        public void Delete(Guid id);

    }
}
