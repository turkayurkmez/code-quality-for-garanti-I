namespace CodeSmells.LongMethod;

internal class TransactionManager
{
    internal Transaction BeginTransaction()
    {
        return new Transaction();
    }
}
