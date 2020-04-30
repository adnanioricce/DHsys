using System.Data;

namespace Tests.Lib.Data
{
    //?Is this worted?
    public class FakeDbCommand : IDbCommand
    {
        public string CommandText { get; set; }
        public int CommandTimeout { get; set; }
        public CommandType CommandType { get; set; }
        public IDbConnection Connection { get; set; }

        public IDataParameterCollection Parameters => throw new System.NotImplementedException();

        public IDbTransaction Transaction { get; set; }
        public UpdateRowSource UpdatedRowSource { get; set; }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }

        public IDbDataParameter CreateParameter()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public int ExecuteNonQuery()
        {
            throw new System.NotImplementedException();
        }

        public IDataReader ExecuteReader()
        {
            throw new System.NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            throw new System.NotImplementedException();
        }

        public object ExecuteScalar()
        {
            throw new System.NotImplementedException();
        }

        public void Prepare()
        {
            throw new System.NotImplementedException();
        }
    }
}