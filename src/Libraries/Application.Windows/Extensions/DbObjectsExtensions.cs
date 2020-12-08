using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Text;

namespace Application.Windows.Extensions
{
    public static class DbObjectsExtensions
    {
        internal static DbDataAdapter GetDataAdapter(this IDbConnection dbConnection)
        {
            if (dbConnection is SqliteConnection) return new SQLiteDataAdapter();
            if (dbConnection is OleDbConnection) return new OleDbDataAdapter();
            return new System.Data.SQLite.SQLiteDataAdapter();
        }
        internal static DbCommandBuilder GetCommandBuilder(this IDbConnection dbConnection, DbDataAdapter adapter)
        {
            if (dbConnection is SQLiteConnection) return new SQLiteCommandBuilder((SQLiteDataAdapter)adapter);
            if (dbConnection is OleDbConnection) return new OleDbCommandBuilder((OleDbDataAdapter)adapter);
            return new System.Data.SQLite.SQLiteCommandBuilder((SQLiteDataAdapter)adapter);
        }
    }
}
