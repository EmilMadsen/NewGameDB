﻿using GameDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> GetAll(String search);
        T Find(int id);
        void Delete(int id);
        void InsertOrUpdate(T data);
    }
}
