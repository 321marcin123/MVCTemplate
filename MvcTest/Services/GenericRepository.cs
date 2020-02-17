namespace MvcTest.Services
{
    using AutoMapper;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        private readonly IMapper mapper;
        private readonly IContext dbcontext;
        private readonly DbSet<T> dbset;


        public GenericRepository(IContext context, IMapper mapper)
        {
            this.dbcontext = context;
            this.dbset = context.Set<T>();
            this.mapper = mapper;
        }


        public T Select(int id)
        {
            var output = dbset.Find(id);
            return output;
        }

        // select by lambda expression
        public T Select(Expression<Func<T, bool>> whereCondition)
        {
            var tmp = dbset.Where(whereCondition).FirstOrDefault();
            return tmp;
        }

        public List<T> SelectAll()

        {
            return dbset.ToList();
        }

        // select all by lambda expression
        public List<T> SelectAll(Expression<Func<T, bool>> whereCondition)
        {
            var tmp = dbset.Where(whereCondition).ToList();
            return tmp;
        }

        public T Create<R>(R entity)
        {

            var model = mapper.Map<R, T>(entity);
            return dbset.Add(model);

        }

        public T Create(T entity)
        {
            return dbset.Add(entity);
        }

        public T Update(T entity)
        {
            var entry = dbcontext.Entry(entity);

            entry.State = EntityState.Added == entry.State ? EntityState.Added : EntityState.Modified;

            return entity;
        }


        public T Update<R>(R entity)
            where R : IUpdate
        {
            var model = Select(entity.Id);
            mapper.Map(entity, model);

            var entry = dbcontext.Entry(model);

            entry.State = EntityState.Added == entry.State ? EntityState.Added : EntityState.Modified;

            return model;

        }
        public int SaveChanges()
        {
            return dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbset.Find(id);
            dbcontext.Entry(entity).State = EntityState.Deleted;
        }

        public void Remove(int id)
        {
            var entity = dbset.Find(id);

            dbset.Remove(entity);
        }

    }
}