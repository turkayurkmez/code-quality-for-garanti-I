using CleanCode.Application;
using CleanCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IBillCalculator billCalculator;

        public NotificationService(IBillCalculator billCalculator)
        {
            this.billCalculator = billCalculator;
        }

        public void SimulateMessage(List<TimeSheetEntry> timeSheetEntries, Company company)
        {

            double weeklyBill = billCalculator.GetWeeklyBill(timeSheetEntries, company);
            Console.WriteLine($"Simulating Sending email to {company.Name} ");
            Console.WriteLine($"Your bill is ${weeklyBill}  for the hours worked.");
        }
    }
}
