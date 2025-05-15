using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //1. Ne elde etmek istiyorsunuz? Builder ne üretecek?
    public class Report
    {
        public string Title { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Tables { get; set; }
        public List<string> Graphs { get; set; }

        public void PrintReport()
        {
            Console.WriteLine($"Başlık: {Title}");
            Console.WriteLine($"Ana Başlık {Header}");
            Console.WriteLine($"İçerik: {Content}");

            if (Authors != null &&  Graphs!= null)
            {
                Authors.ForEach(a => Console.WriteLine(a));
                Graphs.ForEach(g => Console.WriteLine(g));
            }
          



        }
    }

    //2. Report nesnesini üretecek interface'i tanımlayın (Rapor nesnesi nasıl oluşacak)

    public interface IReportBuilder
    {
        //Dikkat!! Her eylemin karmaşık olduğunu varsayın.

        IReportBuilder BuildTitle();
        IReportBuilder BuildHeader();
        IReportBuilder BuildContent();
        IReportBuilder BuildAuthors();
        IReportBuilder BuildTables();
        IReportBuilder BuildGraphs();

        Report BuildReport();

    }

    //3. Üretilecek bir rapor nesnesi oluşturun:

    public class FinancialReportBuilder : IReportBuilder
    {
        private readonly Report report = new Report();
        public IReportBuilder BuildAuthors()
        {
            report.Authors = new List<string>() { "Garanti Finans Dep." };
            return this;
        }

        public IReportBuilder BuildContent()
        {
            report.Content = "Veritabanından ne badireler atlatılarak bu içerik oluştu...";
            return this;
        }

        public IReportBuilder BuildGraphs()
        {
            report.Graphs = new List<string>()
            {
                "Grafikler..."
            };

            return this;

        }

        public IReportBuilder BuildHeader()
        {
            report.Header = "Finansal Rapor Başlığı....";

            return this;
        }

        public Report BuildReport()
        {
            return report;
        }

        public IReportBuilder BuildTables()
        {
            report.Tables = new List<string>() { "Tablolar...." };
            return this;
        }

        public IReportBuilder BuildTitle()
        {
            report.Title = "2025 Q1 Finans Raporu";
            return this;
        }
    }


    public class EmployeePerformanceReportBuilder : IReportBuilder
    {
        private readonly Report report = new Report();
        public IReportBuilder BuildAuthors()
        {
            report.Authors = new List<string> { "İK" };
            return this;
        }

        public IReportBuilder BuildContent()
        {

            report.Content = "Çalışanın yıllık performans analizi";
             return this;
        }

        public IReportBuilder BuildGraphs()
        {
            report.Graphs = new List<string>();
            return this;
        }

        public IReportBuilder BuildHeader()
        {

            report.Header = "[Çaşışan ismi] performans analizi";
            return this;
            
        }

        public Report BuildReport()
        {
            return report;
        }

        public IReportBuilder BuildTables()
        {
            report.Tables = new List<string>();    
            return this;
        }

        public IReportBuilder BuildTitle()
        {
            report.Title = "2025 Yılı PerformansRaporu";
            return this;
        }
    }

    //4. Hangi raporun oluşturulacağını yönetin (Unutmayın! Finans sadece bir örnek, başka yüzlerce rapor sınıfınız var!)

    public class ReportDirector
    {
        private readonly IReportBuilder reportBuilder;

        public ReportDirector(IReportBuilder reportBuilder)
        {
            this.reportBuilder = reportBuilder;
        }

        public Report BuildFullReport()
        {
            return reportBuilder.BuildTitle()
                                .BuildHeader()
                                .BuildAuthors()
                                .BuildContent()
                                .BuildGraphs()
                                .BuildTables()
                                .BuildReport();

        }

        public Report BuildMiniReport()
        {
            return reportBuilder.BuildTitle()
                                .BuildHeader()
                                .BuildAuthors()
                                .BuildContent()
                                .BuildReport();


        }
    }
}
