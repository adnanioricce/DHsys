using System.Data;
using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface ISyncQueryBuilder
    {
        string BuildQueryFrom(params DbfRecordDiff[] records);        
        string BuildQueryFrom(IDbConnection dbConnection,params DataTable[] dataTables);
    }
}