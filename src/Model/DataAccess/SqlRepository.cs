namespace Model.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Model;

    public class SqlRepository<T> : IRepository<T>
        where T : class
    {
        #region Constants and Fields

        private readonly DbSet<T> entitySet;

        #endregion

        #region Constructors and Destructors

        public SqlRepository(DbContext context)
        {
            entitySet = context.Set<T>();
        }

        #endregion

        #region Implemented Interfaces

        #region IRepository<T>

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Add(T newEntity)
        {
            entitySet.Add(newEntity);

        }

        public void Attach(T existingEntity)
        {
            entitySet.Attach(existingEntity);
        }

        public IQueryable<T> FindAll()
        {
            return entitySet;
        }

        public T FindById(params object[] keys)
        {
            return entitySet.Find(keys);
        }

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate)
        {
            return entitySet.Where(predicate);
        }

        public void Remove(T entity)
        {
            entitySet.Remove(entity);
        }

        #endregion

        #endregion
    }
}