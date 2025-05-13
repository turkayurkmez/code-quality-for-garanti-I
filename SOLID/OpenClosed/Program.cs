// See https://aka.ms/new-console-template for more information
using OpenClosed;

Console.WriteLine("Hello, World!");
/*
 * Bir nesne [GELİŞİME] açık, [DEĞİŞİME] kapalı olmalı...
 * 
 */

Customer customer = new Customer() { CardType = new Premium()};
OrderManager orderManager = new OrderManager() {  Customer =customer};
Console.WriteLine(orderManager.GetDiscountetPrice(1000));