﻿using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using System.Collections.Generic;
using System.Data;

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
        /// <summary>
        /// Creates sql string to update columns with values(ie: "UPDATE SET ColumnName='ColumnValue' ")
        /// </summary>
        /// <param name="column">a RecordColumn object to get the column names and values to create the string</param>
        /// <returns>string with the columns to be updated</returns>
        string WriteUpdateSetToCorrectSqlType(RecordColumn column);
        /// <summary>
        /// Create a string insert query from object. The object should be a existing entity type.
        /// </summary>
        /// <param name="value">the object from which get the values to create the sql query</param>
        /// <returns>a insert sql query statement</returns>
        string WriteInsertValuesToCorrectSqlType(object value);
        /// <summary>
        /// Convert a collection of dbf files to a dataset
        /// </summary>
        /// <param name="files"></param>
        /// <returns>a dataset with all the tables loaded from the files</returns>
        DataSet MapDbfsToDataset(string[] files);
        /// <summary>
        /// creates a tuple from the filenames to a SELECT statement for the file table and the tablename of the filename and return it.
        /// </summary>
        /// <param name="filename">the file to</param>
        /// <returns></returns>
        (string Query,string TableName) ConvertFilenameToSelectQuery(string filename);
        /// <summary>
        /// Sync all dbf files in a specified folder path with the current database
        /// </summary>
        void SyncDbfChanges();
        /// <summary>
        /// Sync the changes between a dbf file and the current database
        /// </summary>
        /// <param name="dbfFilePath"></param>
        void SyncDbfChanges(string dbfFilePath);
    }
}
