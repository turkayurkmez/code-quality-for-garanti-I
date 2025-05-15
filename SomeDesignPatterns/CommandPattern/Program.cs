namespace CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /*
             * Belirli bir kaynak (db, api, excel dosyası vs) üzerinde gerçekleşecek olan komutları nasıl daha muntazam yönetirsiniz?
             * 
             * 
             */

            DbCommandReceiver dbCommandReceiver = new DbCommandReceiver();
            CreateNewProductCommand createNewProductCommand = new CreateNewProductCommand(dbCommandReceiver)
            {
                Name ="Test",
                Price = 1

            };

            DiscountProductPrice discountProductPrice = new DiscountProductPrice(dbCommandReceiver)
            {
                Name = "Test",
                Price = 1
            };

            CommandInvoker commandInvoker = new CommandInvoker();
            commandInvoker.AddCommand(createNewProductCommand);
            commandInvoker.AddCommand(discountProductPrice);

            commandInvoker.ExecuteCommand();

        }
    }
}
