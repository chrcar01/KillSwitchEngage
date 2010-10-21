using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KillSwitchEngage.Data.Repositories
{
    public interface IRepository : IDisposable
    {
        IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : class;
        IEnumerable<TEntity> FindAll<TEntity>() where TEntity : class;
        IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        void Save<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
    }
}