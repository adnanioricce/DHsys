using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;

namespace DAL
{
    public class DbfRepository<T> : IRepository<T> where T : class
    {
        private readonly LegacyContext<T> context;
        private readonly string DbName;
        public DbfRepository(string dbfFilePath)
        {
            context = new LegacyContext<T>(dbfFilePath);
            DbName = dbfFilePath;
        }
        public void Add(T entry)
        {
            var fields = entry.GetType().GetProperties().Select(x => new EntityField{
                FieldName = x.Name,
                Value = null
            }).ToArray();   
            var queryBuilder = new StringBuilder();         
            queryBuilder.Append($"INSERT INTO {this.DbName}.dbf VALUES(");
            for (int i = 0; i < fields.Length; i++)
            {                            
                queryBuilder.Append($"@{fields[i].FieldName}");
                queryBuilder.Append(i == fields.Length - 1 ? "" : ",");
                context.Command(queryBuilder.ToString(),entry);                
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return context.MultipleRawQuery($"SELECT * FROM {DbName}.dbf");
        }

        public T GetById(int id)
        {
            return context.RawQuery($"SELECT * FROM {DbName}.dbf WHERE Id = {id} ");
        }        

        public IQueryable<T> Query()
        {
            throw new System.NotImplementedException();
        }
        public IQueryable<T> QueryableByRawQuery(string sql)
        {
            return context.MultipleRawQuery(sql).AsQueryable();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}