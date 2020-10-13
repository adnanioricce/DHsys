using Legacy.Models.Dbf;
using Core.Models.ApplicationResources.Requests;
using System.Data;
using Legacy.Models.Sync;

namespace Legacy.Interfaces.Sync
{
    public interface ILegacyDbSynchronizer
    {
        /// <summary>
        /// Generates a script with the the update or insert script of given Records
        /// </summary>
        /// <param name="request">the request object with data about the records</param>
        /// <returns>a update/insert sql script with the changes</returns>
        string GenerateSyncScriptForEntity(SyncDatabaseRequest request);
                
        /// <summary>
        /// Convert a collection of dbf files to a dataset
        DataSet MapDbfsToDataset(string[] files, IDbConnection dbConnection);
        /// <summary>
        /// loads all tables in each folder in a different dataset, compare it and return.
        /// </summary>
        /// <param name="sourceFolderPath">the folder with the source of the changes</param>
        /// <returns>a dataset with the changes between the datasets</returns>
        DataSet GetChangesBetweenDatabases(string sourceFolderPath);
        /// <summary>
        /// creates a tuple from the filenames to a SELECT statement for the file table and the tablename of the filename and return it.
        /// </summary>
        /// <param name="filename">the file to</param>
        /// <returns></returns>
        (string Query, string TableName) ConvertFilenameToSelectQuery(string filename);
        /// <summary>
        /// Sync all dbf files in a specified folder path with the current database
        /// </summary>
        void SyncDbfChanges();
        /// <summary>
        /// Sync the changes between a dbf file and the current database
        /// </summary>
        /// <param name="dbfFilePath"></param>
        void SyncDbfChanges(string dbfFilePath);
        /// <summary>
        /// Syncronize data from source database to local database
        /// </summary>
        int SyncSourceDatabaseWithLocalDatabase(string sourceDatabaseFolder);
    }
}