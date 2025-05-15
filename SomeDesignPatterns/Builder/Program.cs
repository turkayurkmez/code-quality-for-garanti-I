namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
                      /*
             * Problem;  
             * 
             * Çok aşamadan oluşan ve ancak bu aşamaların sonucunda elde edilen bir nesneniz var. Üstelik bu nesne; implemente edilerek genişleyebilir olmalı. Bu problemi; SOLID'e uyarak nasıl çözersiniz?
             */

            var financialReportBuilder = new FinancialReportBuilder();
            var director = new ReportDirector(financialReportBuilder);

            var financialReport = director.BuildFullReport();
            financialReport.PrintReport();

            var performance = new EmployeePerformanceReportBuilder();
            var performanceReportDirector = new ReportDirector(performance);
            var performanceReport = performanceReportDirector.BuildMiniReport();

            performanceReport.PrintReport();
        }
    }
}
