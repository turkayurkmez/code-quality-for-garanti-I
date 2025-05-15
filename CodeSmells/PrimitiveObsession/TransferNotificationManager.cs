using CodeSmells.LongMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.PrimitiveObsession
{
    internal class TransferNotificationManager
    {
        // Para transferi işlemi
        public TransferResult Transfer(AccountNumber fromAccount, AccountNumber toAccount, Money money)
        {
            // fromAccount ve toAccount sadece string - format kontrolü yok

            // amount negatif olabilir
            // currency geçersiz olabilir

            // Bakiye kontrolü
            var sourceBalance = GetAccountBalance(fromAccount, money.Currency);
            if (sourceBalance < money.Amount)
                return new TransferResult { Success = false, Message = "Insufficient funds" };



            return new TransferResult { Success = true, Message = "Successfull" };
            // Transfer işlemi...
        }

        private double GetAccountBalance(AccountNumber fromAccount, string currency)
        {
            return 0.0;

        }

        // Cep telefonuna para gönderme
        public TransferResult SendToPhone(AccountNumber fromAccount, string phoneNumber, Money money)
        {
            // phoneNumber sadece string - format kontrolü yok

            // Bakiye kontrolü
            var sourceBalance = GetAccountBalance(fromAccount, money.Currency);
            if (sourceBalance < money.Amount)
                return new TransferResult { Success = false, Message = "Insufficient funds" };

            // Transfer işlemi...
            return new TransferResult { Success = true, Message = "Successfull" };

        }


        public record AccountNumber
        {
            private string value;
            public AccountNumber(string value)
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException();
                }

                this.value = value;

            }

            private bool IsValid(string value)
            {
                return true;
            }
        }

        public record Money(double Amount, string Currency);
    }
}
