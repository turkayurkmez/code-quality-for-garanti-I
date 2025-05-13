namespace CodeSmells.LongMethod;

public class TransferResult
{
    public bool Success { get; internal set; }
    public string ErrorCode { get; internal set; }
    public object TransactionId { get; internal set; }
    public decimal ProcessedAmount { get; internal set; }
    public string ProcessedCurrency { get; internal set; }

}
