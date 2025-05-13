// See https://aka.ms/new-console-template for more information
using LiskovSubstution;

Console.WriteLine("Hello, World!");

Pasta pasta = new Pasta();
Cake cake = new Cake();

Chef chef = new Chef();
chef.Cook(pasta);
chef.Cook(cake);


IPaymentCalculator  transfer = new TransferService().CreateTransfer(0.10,null);



double payment = transfer.CalculatePayment();
Console.WriteLine(payment);