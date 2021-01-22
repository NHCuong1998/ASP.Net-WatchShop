using System;
using Dao;

namespace Bus.ControllerImpl
{
    class DataAccess
    {
        private static DataContext db = null;

        private DataAccess()
        {
        }

        public static DataContext GetInstance()
        {
            return db ??= new DataContext();
        }
    }
}
