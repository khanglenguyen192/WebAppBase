using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApp.DBContext;

namespace WebApp.Service
{
    public interface IBaseService<T>
    {
        T GetById(object id);

        bool IsExisted(int id);

        void Insert(T entity);

        void Update(T entity);

        bool Delete(T entity);

        IQueryable<T> Table { get; }

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null);
    }
}