﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tests.Lib.Data
{
    public class FakeRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Dictionary<int, T> context = new();
        private int counter = 1;
        public FakeRepository()
        {
            
        }
        public FakeRepository(IEnumerable<T> data)
        {
            AddRange(data);
        }
        
        
        public void Add(T entry)
        {
            if (entry.Id <= 0)
            {
                entry.Id = counter;
                context.Add(entry.Id, entry);                
                ++counter;
                return;
            }
            entry.Id = counter;
            context.Add(entry.Id, entry);
            counter++;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Delete(T entity)
        {
            context.Remove(context.FirstOrDefault(e => e.Value.Equals(entity)).Key);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Values.AsEnumerable();
        }

        public T GetBy(int id)
        {
            return context[id];
        }

        public IQueryable<T> Query()
        {
            return new TestAsyncEnumerable<T>(context.Values.AsQueryable());
        }

        public int SaveChanges()
        {
            //TODO;
            return 1;
        }

        public void Update(T entity)
        {
            context[entity.Id] = entity;
        }

        public T GetBy(string id)
        {
            return context.Values.FirstOrDefault(i => i.UniqueCode == id);
        }

        public IQueryable<T> Query(string query)
        {
            return new TestAsyncEnumerable<T>(context.Values.AsQueryable()); 
        }

        public Task<T> GetByAsync(int id)
        {
            return Task.FromResult(this.context[id]);
        }

        public Task<T> GetByAsync(string uniqueCode)
        {
            return Task.FromResult(this.context.Values
                                               .Where(v => string.Equals(v.UniqueCode, uniqueCode, System.StringComparison.OrdinalIgnoreCase))
                                               .FirstOrDefault());
        }
        public Task<T> GetByAsync(object id)
        {
            if (id.IsNumber())
            {
                return GetByAsync((int)id);
            }
            else if(id is string @strId)
            {
                return GetByAsync(@strId);
            }
            return Task.FromResult(context[(int)id]);
        }
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(this.context.Select(c => c.Value));
        }

        public Task<int> SaveChangesAsync()
        {
            return Task<int>.FromResult(0);
        }

        public IQueryable<T> MultipleFromRawSql(string sql, params object[] parameters)
        {
            //If this is needed, maybe is better to mock or actually use a Database
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerable<T> GetAsyncEnumerable()
        {
            return new TestAsyncEnumerable<T>(context.Values.AsEnumerable());
        }

        public Task<T> GetByWithNoTrackingAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
