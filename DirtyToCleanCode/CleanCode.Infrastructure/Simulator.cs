using CleanCode.Application;
using CleanCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure
{
    public class Simulator
    {

        private INotificationService notificationService;

        public Simulator(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public  void SimuleEmailToAllCompanies(List<TimeSheetEntry> timeSheetEntries)
        {
            CompanyService companyService = new CompanyService();
            var companies = companyService.GetCompanies();

            foreach (var company in companies)
            {
                notificationService.SimulateMessage(timeSheetEntries, company);
            }
        }
    }
}
