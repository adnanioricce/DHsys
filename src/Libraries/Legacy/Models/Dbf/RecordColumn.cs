using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models.Dbf
{
    public class RecordColumn
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }
        /// <summary>
        /// Creates sql string to update columns with values(ie: "UPDATE SET ColumnName='ColumnValue' ")
        /// </summary>
        /// <param name="column">a RecordColumn object to get the column names and values to create the string</param>
        /// <returns>string with the columns to be updated</returns>
        public string WriteUpdateSetToCorrectSqlType() => this.Value.GetType().Name switch
        {
            "Int32" => $"{this.ColumnName}={Convert.ToInt32(this.Value)}",
            "Int64" => $"{this.ColumnName}={Convert.ToInt64(this.Value)}",
            "Int16" => $"{this.ColumnName}={Convert.ToInt16(this.Value)}",
            "Byte" => $"{this.ColumnName}={Convert.ToByte(this.Value)}",
            "Decimal" => $"{this.ColumnName}={Convert.ToDecimal(this.Value)}",
            "DateTime" => $"{this.ColumnName}={Convert.ToDateTime(this.Value)}",
            "Double" => $"{this.ColumnName}={Convert.ToDouble(this.Value)}",
            _ => $"{this.ColumnName}='{this.Value}'"
        };
        /// <summary>
        /// Create a string insert query from object. The object should be a existing entity type.
        /// </summary>
        /// <param name="value">the object from which get the values to create the sql query</param>
        /// <returns>a insert sql query statement</returns>
        public static string WriteInsertValuesToCorrectSqlType(object value) => value.GetType().Name switch
        {
            "Int32" => $"{Convert.ToInt32(value)}",
            "Int64" => $"{Convert.ToInt64(value)}",
            "Int16" => $"{Convert.ToInt16(value)}",
            "Byte" => $"{Convert.ToByte(value)}",
            "Decimal" => $"{Convert.ToDecimal(value)}",
            "DateTime" => $"{Convert.ToDateTime(value).ToShortDateString()}",
            "Double" => $"{Convert.ToDouble(value.ToString().Replace(',', '.'))}",
            "Single" => $"{Convert.ToSingle(value.ToString().Replace(',', '.'))}",
            "String" => $"'{value.ToString().Replace("'", " ")}'",
            _ => "NULL"
        };
    }
}
