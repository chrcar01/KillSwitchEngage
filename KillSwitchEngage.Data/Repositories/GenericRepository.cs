using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

namespace KillSwitchEngage.Data.Repositories
{
    public class GenericRepository : IRepository
    {
        private ObjectContext _context;
        private PluralizationService _pluralizer;
        private bool _saveChangesOnDispose;
        public GenericRepository(ObjectContext context)
            : this(context, true)
        {
        }
        public GenericRepository(ObjectContext context, bool saveChangesOnDispose)
        {
            _context = context;
            _saveChangesOnDispose = saveChangesOnDispose;
            _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
        }
        private string GetEntitySetName<TEntity>()
        {
            return _pluralizer.Pluralize(typeof(TEntity).Name);
        }
        public IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : class
        {
            return _context.CreateQuery<TEntity>(GetEntitySetName<TEntity>());
        }
        private void SaveChanges()
        {
            if (!_saveChangesOnDispose)
                _context.SaveChanges();
        }
        public IEnumerable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return CreateQuery<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return CreateQuery<TEntity>().Where(predicate).AsEnumerable();
        }

        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return CreateQuery<TEntity>().Where(predicate).SingleOrDefault();
        }

        public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return CreateQuery<TEntity>().Where(predicate).FirstOrDefault();
        }

        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            var key = _context.CreateEntityKey(GetEntitySetName<TEntity>(), entity);
            object existingEntity;
            if (_context.TryGetObjectByKey(key, out existingEntity))
            {
                _context.ApplyCurrentValues<TEntity>(GetEntitySetName<TEntity>(), entity);
            }
            else
            {
                _context.AddObject(GetEntitySetName<TEntity>(), entity);
            }
            SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.DeleteObject(entity);
            SaveChanges();
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitiesToDelete = FindAll<TEntity>(predicate);
            if (entitiesToDelete == null || entitiesToDelete.Count() == 0)
                return;

            foreach (var entity in entitiesToDelete)
            {
                Delete<TEntity>(entity);
            }
        }
        public void Dispose()
        {
            if (_saveChangesOnDispose)
                _context.SaveChanges();
        }
    }
}
