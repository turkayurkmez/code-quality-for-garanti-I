using System.Data;

namespace CleanCode.Naming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //1. Her zaman anlamlı isimler kullanın. 
                  //  -- Değişkeni açıklamak için; satır yazıyorsanız, değişkeninizin ismi yanlıştır.
            
            int daysSinceUserCreated = 0; //bu değişken, müşterinin kaydından bu yana geçen gün süresini tutar.

            //2. kodla şaka olmaz :)
            bool banuAlkan = false;

            //3. Kısaltma; o domain için anlamlı ise kullanın.
            int hp = 0;

            //4. Değişken ya da fonksiyon adını; tipe göre verin:
            bool hasData = false;
            int currentMonth = 5;
            double taxRate = 0.2;


            //Code Guideline ihtiyacı...
            var emails = new List<string>();
            var emailList = new List<string>();

            string password = "pa55Word";

            bool isAvailableLength = password.Length >= 6;
            bool isIncludeLetter = isCountainLetter(password);
            bool isIncludeNumber = isContainNumber(password);
            bool isIncludeSymbol = isContainSymbol(password);

            bool isPasswordAvailable = isAvailableLength && 
                                       isIncludeLetter && 
                                       isIncludeNumber && 
                                       isIncludeSymbol;

            if (isPasswordAvailable)
            {
                //
            }
            
            
        }

        private static bool isContainSymbol(string password)
        {
            throw new NotImplementedException();
        }

        private static bool isContainNumber(string password)
        {
            throw new NotImplementedException();
        }

        private static bool isCountainLetter(string password)
        {
            throw new NotImplementedException();
        }

        static dynamic accountRepository;
        static void processWithdrawal(string accountNumber, bool isConfirmed, decimal amount)
        {
            if (!isConfirmed)
            {
                return;
            }


            var userAccount = accountRepository.GetAccountByNumber(accountNumber);
            userAccount.Balance -= amount;

            if (userAccount.AccountType == "Premium")
            {
                userAccount.Balance -= amount * 0.001m;
            }
            accountRepository.Update(accountNumber);

        }


        static  List<int[]> cellsOnABoard = new List<int[]>();

        static List<int[]> getFlaggedCells()
        {
            List<int[]> flaggedCells = new List<int[]>();
            foreach (var cell in cellsOnABoard)
            {
                if (cell[0] == CellState.Flagged)
                {
                    flaggedCells.Add(cell);
                }
            }

            return flaggedCells;
        }

       

    }

    public class CellState
    {
        public const int Empty = 1;
        public const int Exploded = 2;
        public const int Flagged = 4;
        public const int Opened = 8;

    }



}
