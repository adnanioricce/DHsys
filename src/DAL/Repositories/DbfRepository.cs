using Core.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbfRepository<T> : ILegacyRepository<T> where T : class 
    {
        private readonly LegacyContext<T> _context;
        private readonly string DbName;
        public DbfRepository(LegacyContext<T> context,IOptions<LegacyDatabaseSettings> dbSettings)
        {
            _context = context;
            DbName = $"{dbSettings.Value.DataSource}\\{typeof(T).Name.ToUpper()}.dbf";
        }
        public void Add(T entry)
        {
            var fields = entry.GetType().GetProperties().Select(x => new EntityField{
                FieldName = x.Name,
                Value = null
            }).ToArray();   
            var queryBuilder = new StringBuilder();         
            queryBuilder.Append($"INSERT INTO {this.DbName} VALUES(");
            for (int i = 0; i < fields.Length; i++)
            {                            
                queryBuilder.Append($"@{fields[i].FieldName}");
                queryBuilder.Append(i == fields.Length - 1 ? "" : ",");
                _context.Command(queryBuilder.ToString(),entry);                
            }
        }

        public void Command(string query, T entity)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(string id)
        {
            return _context.RawQuery($"SELECT * FROM {DbName} WHERE prcodi = {id}");
        }

        public IEnumerable<T> MultipleFromRawSqlQuery(string query)
        {
            return _context.MultipleFromRawQuery(query);
        }        
        public async Task<IEnumerable<T>> MultipleFromRawSqlQueryAsync(string query)
        {
            return await _context.MultipleFromRawQueryAsync(query);
        }
        public IQueryable<T> QueryableByRawQuery(string query)
        {
            return _context.MultipleFromRawQuery(query).AsQueryable();
        }

        public T RawSqlQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entry)
        {
            throw new System.NotImplementedException();
        }
    }
}