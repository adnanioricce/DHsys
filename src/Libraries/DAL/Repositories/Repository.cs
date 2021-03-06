﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Entities;
using DAL.DbContexts;
using DAL.Extensions;
using System.Reflection;
using System.Threading.Tasks;
using Core.Extensions;
using System;
using Core.Interfaces.Data;
using Dapper;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected virtual DHsysContext Context { get; }
        protected virtual DbSet<T> DbSet { get; }
        public Repository(DHsysContext context) 
        {            
            Context = context;
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
            foreach(var entity in DbSet.AsNoTracking()){
                yield return entity;
            }            
        }

        public virtual T GetBy(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> Query()
        {
            return DbSet;
        }
        public virtual IAsyncEnumerable<T> GetAsyncEnumerable()
        {            
            return DbSet.AsAsyncEnumerable();            
        }
        public virtual IQueryable<T> MultipleFromRawSql(string sql,params object[] parameters)
        {
            return Context.Set<T>().FromSqlRaw<T>(sql,parameters);
        }
        public virtual void Update(T entity)
        {            
            DbSet.Update(entity);
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual T GetBy(string id)
        {
            return Context.Find<T>(id);
        }

        public virtual IQueryable<T> Query(string query)
        {
            return DbSet.FromSqlRaw<T>(query);
        }        
        public virtual async Task<T> GetByAsync(object id)
        {
            if (id.IsNumber())
            {
                return await GetByAsync((int)id);
            }
            else if (id is string @string)
            {
                return await GetByAsync(@string);
            }
            return await Context.FindAsync<T>(id);
        }
        public virtual async Task<T> GetByAsync(int id)
        {
            return await Context.FindAsync<T>(id);
        }

        public virtual async Task<T> GetByAsync(string uniqueCode)
        {
            return await Context.FindAsync<T>(uniqueCode);
        }
        public Task<T> GetByWithNoTrackingAsync(int id)
        {
            return Context.Set<T>().AsNoTracking().OrderBy(e => e.Id).FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}
