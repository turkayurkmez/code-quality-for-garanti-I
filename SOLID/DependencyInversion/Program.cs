// See https://aka.ms/new-console-template for more information
using DependencyInversion;

Console.WriteLine("Hello, World!");

MailSender mailSender = new MailSender();
ReportPublisher reportPublisher = new ReportPublisher(mailSender);
reportPublisher.Publish();

WhatsAppSender whatsAppSender = new WhatsAppSender();
TelegramSender telegramSender = new TelegramSender();

ReportPublisher whatsReport = new ReportPublisher(whatsAppSender);
whatsReport.Publish();

ReportPublisher telegramReport = new ReportPublisher(telegramSender);
telegramReport.Publish();