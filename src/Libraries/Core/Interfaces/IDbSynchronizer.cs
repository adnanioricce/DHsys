using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDbSynchronizer
    {
        /// <summary>
        /// Generates a script with the the update or insert script of given Records
        /// </summary>
        /// <param name="request">the request object with data about the records</param>
        /// <returns>a update/insert sql script with the changes</returns>
        string GenerateSyncScriptForEntity(SyncDatabaseRequest request);
        string WriteUpdateSetToCorrectSqlType(RecordColumn column);

        void SyncDbfChanges();
    }
}
