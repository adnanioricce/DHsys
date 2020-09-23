using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Lib.Data
{
    public class TestAsyncEnumerable<TEntity> : EnumerableQuery<TEntity>, IAsyncEnumerable<TEntity>, IQueryable<TEntity>
    {
        private Expression expression;
        public TestAsyncEnumerable(IEnumerable<TEntity> enumerable) : base(enumerable)
        {

        }
        public TestAsyncEnumerable(Expression expression) : base(expression)
        {
            
        }        

        public IQueryProvider Provider
        {
            get { return new TestAsyncQueryProvider<TEntity>(this); }
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new TestAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }        
    }
    public class TestAsyncEnumerator<TEntity> : IAsyncEnumerator<TEntity>
    {
        private readonly IEnumerator<TEntity> _inner;
        public TestAsyncEnumerator(IEnumerator<TEntity> enumerator)
        {
            _inner = enumerator;
        }
        public TEntity Current
        {
            get { return _inner.Current; }
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return default(ValueTask);
        }

        public ValueTask<bool> MoveNextAsync()
        {            
            return new ValueTask<bool>(_inner.MoveNext());
        }
    }
}