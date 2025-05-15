using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
   //1. Tüm komutların ortak olmasını sağla:
   public interface ICommand
    {
        //Tavsiye: komutları takip edin.
        public int Id { get; set; }
        void Execute();
    }

    //2. Komutları kim çalıştıracak? - AŞÇI kim?

    public class DbCommandReceiver 
    {
        public void CreateNewProduct(string name, double price)
        {
            Console.WriteLine("Ekledim");
        }

        public void DiscountProductPrice(string name, double price) {
            Console.WriteLine("Fiyatta indirim yapıldı");
        }

    }

    //3. Komutlarınızı oluşturun:

    public class CreateNewProductCommand : ICommand
    {
        public int Id { get; set; }

        //Her komut, alıcısını tanımalı.

        DbCommandReceiver receiver;

        public CreateNewProductCommand(DbCommandReceiver receiver)
        {
            this.receiver = receiver;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public void Execute()
        {
            receiver.CreateNewProduct(Name, Price); 
        }
    }

    public class DiscountProductPrice : ICommand
    {
        private DbCommandReceiver receiver;

        public DiscountProductPrice(DbCommandReceiver receiver)
        {
            this.receiver = receiver;
        }

        public int Id { get; set ; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void Execute()
        {
            receiver.DiscountProductPrice(Name, Price); 
        }
    }


    public class CommandInvoker
    {
        private  Queue<ICommand> commands = new();

        public void AddCommand(ICommand command)
        {
            commands.Enqueue(command);
        }

        public void Clear() => commands.Clear();
        public void Remove(ICommand command) => commands = new Queue<ICommand>(commands.Where(c => c != command));

        public void ExecuteCommand()
        {
            while (commands.Count>0)
            {
                var command = commands.Dequeue();
                command.Execute();
            }
        }

    }
}
