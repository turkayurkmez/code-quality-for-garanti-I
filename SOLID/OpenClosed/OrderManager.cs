using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{

    //public enum CardType
    //{
    //    Standard,
    //    Silver,
    //    Gold
    //}

    public abstract class CardType
    {
        public abstract decimal DiscountRate();
    }

    public class Standard : CardType
    {
        public override decimal DiscountRate()
        {
            return .95m;
        }
    }

    public class Silver : CardType
    {
        public override decimal DiscountRate()
        {
            return .9m;
        }
    }

    public class Gold : CardType
    {
        public override decimal DiscountRate()
        {
            return .85m;
        }
    }

    public class Premium : CardType
    {
        public override decimal DiscountRate()
        {
            return 0.8m;
        }
    }

    public class Customer
    {
        public CardType CardType { get; set; }
    }
    public class OrderManager
    {
        public Customer Customer { get; set; }
        public decimal GetDiscountetPrice(decimal total)
        {
            //switch (Customer.CardType)
            //{
            //    case CardType.Standard:

            //        return total * .95m;

            //    case CardType.Silver:

            //        return total * .9m;
            //    case CardType.Gold:
            //        return total * .85m;
            //    default:
            //        return total;
            //}

            return Customer.CardType.DiscountRate() * total;
        }
    }
}
