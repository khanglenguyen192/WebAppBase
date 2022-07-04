using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApp.Data;
using WebApp.DBContext;

namespace WebApp.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        public BaseService()
        {
            _context = new Context();
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public bool IsExisted(int id)
        {
            return Entities.Find(id) != null;
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                // Add to DBContext
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null)
        {
            var query = from b in Table
                        select b;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query;
        }
    }
}
