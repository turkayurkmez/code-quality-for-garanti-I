using CleanCode.Entities;

namespace CleanCode.Application
{
    public interface IBillCalculator
    {
        double GetExtraPayment(List<TimeSheetEntry> timeSheetEntries, ExtraPaymentOptions options);
        double GetWeeklyBill(List<TimeSheetEntry> timeSheetEntries, Company company);
    }
}