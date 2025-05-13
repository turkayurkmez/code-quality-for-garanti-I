namespace CodeSmells.LongMethod;

public class Transaction : IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    internal void Commit()
    {
        throw new NotImplementedException();
    }

    internal void Rollback()
    {
        throw new NotImplementedException();
    }
}
