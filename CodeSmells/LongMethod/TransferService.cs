using System.Transactions;
using System;

namespace CodeSmells.LongMethod;

public class TransferService
{
    private AccountRepository _accountRepository;
    private TransactionRepository _transactionRepository;
    private ComplientService _complianceService;
    private SecurityService _securityService;
    private FeeCalculationService _feeCalculationService;
    private ExchangeRateService _exchangeRateService;

    private TransactionManager _transactionManager;
    private NotificationService _notificationService;
    private Logger _logger;

    public TransferResult ExecuteTransfer(string fromAccount, string toAccount, decimal amount, string currency, bool isInternational, string description, string referenceNumber)
    {
        // 1. Giriş doğrulama
        if (string.IsNullOrEmpty(fromAccount) || string.IsNullOrEmpty(toAccount))
        {
            return new TransferResult { Success = false, ErrorCode = "INVALID_ACCOUNT" };
        }

        if (amount <= 0)
        {
            return new TransferResult { Success = false, ErrorCode = "INVALID_AMOUNT" };
        }

        // 2. Hesapları getir
        var sourceAccount = _accountRepository.GetByNumber(fromAccount);
        var targetAccount = _accountRepository.GetByNumber(toAccount);

        if (sourceAccount == null)
        {
            return new TransferResult { Success = false, ErrorCode = "SOURCE_NOT_FOUND" };
        }

        if (targetAccount == null)
        {
            return new TransferResult { Success = false, ErrorCode = "TARGET_NOT_FOUND" };
        }

        // 3. Bakiye kontrolü
        if (sourceAccount.Balance < amount)
        {
            return new TransferResult { Success = false, ErrorCode = "INSUFFICIENT_FUNDS" };
        }

        // 4. Limit kontrolü
        decimal dailyLimit = sourceAccount.DailyTransferLimit;
        decimal todayTransfers = _transactionRepository.GetTodayTransferAmount(fromAccount);

        if (todayTransfers + amount > dailyLimit)
        {
            return new TransferResult { Success = false, ErrorCode = "DAILY_LIMIT_EXCEEDED" };
        }

        // 5. Uluslararası transfer ise ek kontroller
        if (isInternational)
        {
            // SWIFT kodu kontrolü
            if (string.IsNullOrEmpty(targetAccount.SwiftCode))
            {
                return new TransferResult { Success = false, ErrorCode = "MISSING_SWIFT_CODE" };
            }

            // Kara liste kontrolü
            var blacklistCheck = _complianceService.CheckBlacklist(targetAccount.Owner.Name, targetAccount.Owner.Country);
            if (!blacklistCheck.IsClean)
            {
                _securityService.ReportSuspiciousActivity(sourceAccount.Id, "Blacklisted recipient");
                return new TransferResult { Success = false, ErrorCode = "COMPLIANCE_CHECK_FAILED" };
            }

            // Uluslararası transfer ücreti
            decimal fee = _feeCalculationService.CalculateInternationalFee(amount, sourceAccount.Type);
            sourceAccount.Balance -= fee;

            // Döviz çevirisi
            if (currency != sourceAccount.Currency)
            {
                decimal exchangeRate = _exchangeRateService.GetRate(sourceAccount.Currency, currency);
                amount = amount * exchangeRate;
            }
        }

        // 6. İşlemi gerçekleştir
        using (Transaction transaction = _transactionManager.BeginTransaction())
        {
            try
            {
                sourceAccount.Balance -= amount;
                _accountRepository.Update(sourceAccount);

                targetAccount.Balance += amount;
                _accountRepository.Update(targetAccount);

                // 7. İşlem kaydı oluştur
                var transactionRecord = new TransactionRecord
                {
                    FromAccount = fromAccount,
                    ToAccount = toAccount,
                    Amount = amount,
                    Currency = currency,
                    Description = description,
                    ReferenceNumber = referenceNumber,
                    TransactionDate = DateTime.UtcNow,
                    Type = isInternational ? TransactionType.InternationalTransfer : TransactionType.DomesticTransfer
                };

                _transactionRepository.Add(transactionRecord);

                // 8. Bildirim gönder
                _notificationService.SendTransferNotification(sourceAccount.Owner.Email, transactionRecord);

                transaction.Commit();

                return new TransferResult
                {
                    Success = true,
                    TransactionId = transactionRecord.Id,
                    ProcessedAmount = amount,
                    ProcessedCurrency = currency
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Transfer failed");
                return new TransferResult { Success = false, ErrorCode = "SYSTEM_ERROR" };
            }
        }
    }

}
