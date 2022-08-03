﻿using Hospital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}