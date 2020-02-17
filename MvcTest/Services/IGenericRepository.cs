using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcTest.Services
{
    public interface IGenericRepository<T> where T : class
    {
        T Select(int id);

        T Select(Expression<Func<T, bool>> whereCondition);

        List<T> SelectAll();

        List<T> SelectAll(Expression<Func<T, bool>> whereCondition);


        T Update(T entity);

        T Update<R>(R entity)
            where R : IUpdate;

        T Create(T entity);
        T Create<R>(R entity);

        void Delete(int id);

        int SaveChanges();

        void Remove(int id);




    }
}
