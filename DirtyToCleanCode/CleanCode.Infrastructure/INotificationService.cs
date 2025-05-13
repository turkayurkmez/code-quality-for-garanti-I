using CleanCode.Entities;

namespace CleanCode.Infrastructure
{
    public interface INotificationService
    {
        void SimulateMessage(List<TimeSheetEntry> timeSheetEntries, Company company);
    }
}