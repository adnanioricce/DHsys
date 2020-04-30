using System.Data;

namespace Tests.Lib.Data
{
    public class FakeDbConnection : IDbConnection
    {
        public string ConnectionString { get; set; }

        public int ConnectionTimeout => 300;

        public string Database => "TestDatabase";

        public ConnectionState State { get; private set; }

        public IDbTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            this.State = ConnectionState.Closed;
        }

        public IDbCommand CreateCommand()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public void Open()
        {
            State = ConnectionState.Open;
        }
    }
}