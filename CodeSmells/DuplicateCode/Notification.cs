using CodeSmells.LongMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.DuplicateCode
{
    public class Notification
    {
        private dynamic _customerRepository;
        private dynamic _accountRepository;
        private dynamic _transactionRepository;
        private dynamic _emailService;
        private dynamic _notificationRepository;
        private dynamic _cardRepository;

        public dynamic NotificationType { get; private set; }

        // Müşteri hesap özeti e-postası gönderme

        //public void SendAccountSummaryEmail(int customerId)
        //{
        //    var customer = _customerRepository.GetById(customerId);
        //    if (customer == null)
        //        throw new ArgumentException("Customer not found");

        //    var accounts = _accountRepository.GetAccountsByCustomerId(customerId);
        //    var transactions = _transactionRepository.GetRecentTransactions(customerId, 30);

        //    var emailBody = new StringBuilder();
        //    emailBody.AppendLine($"Dear {customer.FirstName} {customer.LastName},");
        //    emailBody.AppendLine("Here is your monthly account summary:");
        //    emailBody.AppendLine();

        //    foreach (var account in accounts)
        //    {
        //        emailBody.AppendLine($"Account: {account.Number}");
        //        emailBody.AppendLine($"Type: {account.Type}");
        //        emailBody.AppendLine($"Balance: {account.Balance:C}");
        //        emailBody.AppendLine();
        //    }

        //    emailBody.AppendLine("Recent Transactions:");
        //    foreach (var transaction in transactions)
        //    {
        //        emailBody.AppendLine($"{transaction.Date}: {transaction.Description} - {transaction.Amount:C}");
        //    }

        //    emailBody.AppendLine();
        //    emailBody.AppendLine("Thank you for banking with us.");
        //    emailBody.AppendLine("XYZ Bank");

        //    _emailService.SendEmail(customer.Email, "Your Monthly Account Summary", emailBody.ToString());
        //    _notificationRepository.RecordNotification(customerId, NotificationType.AccountSummary);
        //}

        // Kredi kartı özeti e-postası gönderme
        //public void SendCreditCardSummaryEmail(int customerId)
        //{
        //    var customer = _customerRepository.GetById(customerId);
        //    if (customer == null)
        //        throw new ArgumentException("Customer not found");

        //    var cards = _cardRepository.GetCardsByCustomerId(customerId);
        //    var transactions = _transactionRepository.GetRecentCardTransactions(customerId, 30);
        //}
        //    var emailBody = new StringBuilder();
        //    emailBody.AppendLine($"Dear {customer.FirstName} {customer.LastName},");
        //    emailBody.AppendLine("Here is your monthly credit card summary:");
        //    emailBody.AppendLine();

        //    foreach (var card in cards)
        //    {
        //        emailBody.AppendLine($"Card: {card.MaskedNumber}");
        //        emailBody.AppendLine($"Type: {card.Type}");
        //        emailBody.AppendLine($"Balance: {card.Balance:C}");
        //        emailBody.AppendLine($"Available Credit: {card.CreditLimit - card.Balance:C}");
        //        emailBody.AppendLine();
        //    }

        //    emailBody.AppendLine("Recent Transactions:");
        //    foreach (var transaction in transactions)
        //    {
        //        emailBody.AppendLine($"{transaction.Date}: {transaction.Description} - {transaction.Amount:C}");
        //    }

        //    emailBody.AppendLine();
        //    emailBody.AppendLine("Thank you for banking with us.");
        //    emailBody.AppendLine("XYZ Bank");

        //    _emailService.SendEmail(customer.Email, "Your Monthly Credit Card Summary", emailBody.ToString());
        //    _notificationRepository.RecordNotification(customerId, NotificationType.CreditCardSummary);


        public void SendAccountSummaryEmail(int customerId)
        {
            SendSummaryMail(customerId, "Monthly account summary", "Account", GenereateAccountSummaryContent, CodeSmells.NotificationType.Account);


        }

        private void SendCardSummaryEmail(int customerId)
        {
            SendSummaryMail(customerId, "Monthly Credit Card", "Credit Card", GenerateCreditCardSummaryContent, CodeSmells.NotificationType.Card);

        }


        private void SendSummaryMail(
              int customerId,
              string subject,
              string summaryType,
              Func<int, string> getContentfunc,
              NotificationType notificationType
            )
        {
            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            var emailBody = new StringBuilder();
            emailBody.AppendLine($"Dear {customer.FirstName} {customer.LastName},");
            emailBody.AppendLine($"Here is your monthly {summaryType} summary:");
            emailBody.AppendLine();

            string content = getContentfunc(customerId);
            emailBody.AppendLine(content);


            emailBody.AppendLine();
            emailBody.AppendLine("Thank you for banking with us.");
            emailBody.AppendLine("XYZ Bank");

            _emailService.SendEmail(customer.Email, subject, emailBody.ToString());
            _notificationRepository.RecordNotification(customerId, NotificationType.AccountSummary);

        }

        private string GenereateAccountSummaryContent(int customerId)
        {
            var accounts = _accountRepository.GetAccountsByCustomerId(customerId);
            var transactions = _transactionRepository.GetRecentTransactions(customerId, 30);

            var emailBody = new StringBuilder();
            foreach (var account in accounts)
            {
                emailBody.AppendLine($"Account: {account.Number}");
                emailBody.AppendLine($"Type: {account.Type}");
                emailBody.AppendLine($"Balance: {account.Balance:C}");
                emailBody.AppendLine();
            }

            emailBody.AppendLine("Recent Transactions:");
            foreach (var transaction in transactions)
            {
                emailBody.AppendLine($"{transaction.Date}: {transaction.Description} - {transaction.Amount:C}");
            }

            return emailBody.ToString();
        }

        private string GenerateCreditCardSummaryContent(int customerId)
        {
            var cards = _cardRepository.GetCardsByCustomerId(customerId);
            var transactions = _transactionRepository.GetRecentCardTransactions(customerId, 30);

            var emailBody = new StringBuilder();


            foreach (var card in cards)
            {
                emailBody.AppendLine($"Card: {card.MaskedNumber}");
                emailBody.AppendLine($"Type: {card.Type}");
                emailBody.AppendLine($"Balance: {card.Balance:C}");
                emailBody.AppendLine($"Available Credit: {card.CreditLimit - card.Balance:C}");
                emailBody.AppendLine();
            }

            emailBody.AppendLine("Recent Transactions:");
            foreach (var transaction in transactions)
            {
                emailBody.AppendLine($"{transaction.Date}: {transaction.Description} - {transaction.Amount:C}");
            }


            return emailBody.ToString();
        }

    }
}

namespace CodeSmells
{
    enum NotificationType
    {
        Account,
        Card
    }
}