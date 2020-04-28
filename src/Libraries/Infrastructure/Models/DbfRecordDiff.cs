using System.Collections.Generic;
namespace Infrastructure.Models
{
	public class DbfRecordDiff
    {
        public DbfRecordDiff()
        {
            
        }
        public DbfRecordDiff(DbfRecord record,int recordIndex)
        {            
            Record = record;
            RecordIndex = recordIndex;
            State = DiffState.Unmodified;            
        }        
        public int RecordIndex { get; set; }
        public DbfRecord Record { get; set; }
        public List<DbfColumnChange> ColumnsChanged { get; set; } = new List<DbfColumnChange>();       
        public DiffState State { get; set; }
        
    }
    public class DbfColumnChange
    {        
        public DbfField Field { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }

    }
    public enum DiffState
    {
        Modified,
        Unmodified,
        New         
    }
}