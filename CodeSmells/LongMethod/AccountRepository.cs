namespace CodeSmells.LongMethod;

internal class AccountRepository
{
    public Account GetByNumber(string fromAccount)
    {
        return new Account();
    }

    internal void Update(Account sourceAccount)
    {
        throw new NotImplementedException();
    }
}
