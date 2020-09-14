using System.Data;
using Infrastructure.Windows.Models;

namespace Infrastructure.Windows.Interfaces
{
    public interface ISyncQueryBuilder
    {
        string BuildQueryFrom(params DbfRecordDiff[] records);        
        string BuildQueryFrom(IDbConnection dbConnection,params DataTable[] dataTables);
    }
}