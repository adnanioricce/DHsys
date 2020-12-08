using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Infrastructure.Windows.Models;
using Infrastructure.Windows.Interfaces;

namespace Application.Windows.Services.Sync
{
    public class SyncQueryBuilder : ISyncQueryBuilder
    {
        private readonly StringBuilder queryBuilder = new StringBuilder();                
        public string BuildQueryFrom(params DbfRecordDiff[] records)
        {
            //TODO:
            return null;
        }        
        public string BuildQueryFrom(IDbConnection dbConnection,params DataTable[] dataTables)
        {
            //TODO:
            using var command = dbConnection.CreateCommand();            
            Dictionary<string,List<string>> columns = new Dictionary<string, List<string>>();
            List<string> queryTemplates = new List<string>();                         
            for (int i = 0; i < dataTables.Length; ++i)
            {
                columns.Add(dataTables[i].TableName,null);
                var columnNames = new List<string>();
                for(int j = 0; j < dataTables[i].Columns.Count;++j){                    
                    columnNames.Add(dataTables[i].Columns[j].ColumnName);                    
                }
                columns[dataTables[i].TableName] = columnNames;
            }    
            return null;            
        }                
    }
}