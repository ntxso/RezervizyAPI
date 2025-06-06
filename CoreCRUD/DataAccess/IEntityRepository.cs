﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void AddRange(List<T> list);
        void Update(T entity);
        void Delete(T entity);
        void MultiDelete(Expression<Func<T, bool>> filter);
        void DeleteRange(List<T> list);

    }
}
