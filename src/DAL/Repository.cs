using Core.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected virtual MainContext Context { get; }
        protected virtual DbSet<T> DbSet { get; }
        public Repository(DbContext dbContext)
        {
            Context = (MainContext)dbContext;
            DbSet = Context.Set<T>();
        }
        public virtual void Add(T entry)
        {
            DbSet.Add(entry);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> Query()
        {
            return DbSet;
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
