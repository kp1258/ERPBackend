using System;
using System.Linq;
using System.Linq.Expressions;
using ERPBackend.Contracts;
using ERPBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERPBackend.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ERPContext ERPContext { get; set; }

        public RepositoryBase(ERPContext erpContext)
        {
            this.ERPContext = erpContext;
        }
        public void Create(T entity)
        {
            this.ERPContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.ERPContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.ERPContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ERPContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.ERPContext.Set<T>().Update(entity);
        }
    }
}