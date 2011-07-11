namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T: class
    {
        void Add(IEnumerable<T> entities);

        void Add(T newEntity);

        void Attach(T existingEntity);

        IQueryable<T> FindAll();

        T FindById(params object[] ids);

        IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate);

        void Remove(T entity);
    }
}