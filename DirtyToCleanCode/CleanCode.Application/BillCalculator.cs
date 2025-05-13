using CleanCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Application
{
    public class BillCalculator : IBillCalculator
    {
        public double GetWeeklyBill(List<TimeSheetEntry> timeSheetEntries, Company company)
        {

            var totalHours = timeSheetEntries
                                  .Where(x => x.WorkDone.ToLower().Contains(company.Name.ToLower()))
                                  .Sum(x => x.HoursWorked);

            return totalHours * company.HourlyPrice;

        }

        public double GetExtraPayment(List<TimeSheetEntry> timeSheetEntries, ExtraPaymentOptions options)
        {
            double totalHours = timeSheetEntries.Sum(t => t.HoursWorked);
            double extraHour = totalHours - options.MaxHoursInAWeek;
            double totalExtraPayment = extraHour * options.ExtraPayment;
            double totalStandardPayment = options.MaxHoursInAWeek * options.StandardPayment;
            double extraTotal = totalExtraPayment + totalStandardPayment;

            double onlyStandardPayment = (totalHours - options.MaxHoursInAWeek) * options.StandardPayment;


            return Math.Max(extraTotal, onlyStandardPayment);


        }
    }
}
