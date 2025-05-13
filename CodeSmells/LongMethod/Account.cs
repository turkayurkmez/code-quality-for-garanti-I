namespace CodeSmells.LongMethod;

internal class Account
{
    public decimal Balance { get; internal set; }
    public decimal DailyTransferLimit { get; internal set; }
    public string? SwiftCode { get; internal set; }
    public Owner Owner { get; internal set; }
    public int Id { get; internal set; }
    public string Type { get; internal set; }
    public string Currency { get; internal set; }
}
