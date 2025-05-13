using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public interface IPaymentCalculator
    {
        double CalculatePayment();
    }
    public class TransferService
    {
        public IPaymentCalculator CreateTransfer(double taxRate, double? commission)
        {
            //bir biçimde....
            if (commission.HasValue)
            {
                return new Transfer { Commission=commission.Value, TaxRate=taxRate};
            }
            return new InternationalTransfer() { TaxRate = taxRate};
        }
    }

    public class Transfer : IPaymentCalculator
    {
        public string IBAN { get; set; }

        public double TaxRate { get; set; }

        public virtual double Commission { get; set; }


        public double CalculatePayment()
        {
            return TaxRate + Commission;
        }

    }

    public class InternationalTransfer : IPaymentCalculator
    {
        public string SwiftCode { get; set; }

        public InternationalTransfer()
        {
          
        }

        public double TaxRate { get; set; }

        public double CalculatePayment()
        {
            return TaxRate;
        }
    }



}
