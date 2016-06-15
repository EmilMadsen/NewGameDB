using GameDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB.Repositories
{
    interface IRepository<T>
    {
        List<T> GetAll();
        T Find(int id);
        void Delete(int id);
        void InsertOrUpdate(T data);
    }
}
