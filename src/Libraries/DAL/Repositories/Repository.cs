using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Entities;
using DAL.DbContexts;
using DAL.Extensions;
using System.Reflection;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected virtual BaseContext Context { get; }
        protected virtual DbSet<T> DbSet { get; }
        public Repository(DbContextResolver contextResolver) 
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Context = assemblyName.Contains("Api") ? contextResolver("remote") : contextResolver("local");
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

        public virtual T GetBy(int id)
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

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public T GetBy(string id)
        {
            return Context.Find<T>(id);
        }

        public IQueryable<T> Query(string query)
        {
            return DbSet.FromSqlRaw<T>(query);
        }

        public async Task<T> GetByAsync(int id)
        {
            return await Context.FindAsync<T>(id);
        }

        public async Task<T> GetByAsync(string uniqueCode)
        {
            return await Context.FindAsync<T>(uniqueCode);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
