using System.Linq.Expressions;

namespace SplitSpendingTests;
public class AsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
{
    public AsyncEnumerable(Expression expression)
        : base(expression) { }

  
    public IAsyncEnumerator<T> GetEnumerator() =>
        new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return GetEnumerator();
    }
}

public class AsyncEnumerator<T> : IAsyncEnumerator<T>
{
    private readonly IEnumerator<T> enumerator;

    public AsyncEnumerator(IEnumerator<T> enumerator) =>
        this.enumerator = enumerator ?? throw new ArgumentNullException();

    public T Current => enumerator.Current;

    public void Dispose() { }

    public async ValueTask DisposeAsync()
    {
        Dispose();
        return;
    }

    public Task<bool> MoveNext(CancellationToken cancellationToken) =>
        Task.FromResult(enumerator.MoveNext());

    public ValueTask<bool> MoveNextAsync()
    {
        return ValueTask.FromResult(enumerator.MoveNext());
    }
}