namespace CodeSmells.LongMethod;

internal class TransactionRecord
{
    public string FromAccount { get; set; }
    public string ToAccount { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public string ReferenceNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionType Type { get; set; }
    public object Id { get; set; }
}
