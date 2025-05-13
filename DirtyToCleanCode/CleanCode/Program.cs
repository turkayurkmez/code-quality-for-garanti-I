using CleanCode.Application;
using CleanCode.Entities;
using CleanCode.Infrastructure;

namespace CleanCode
{

    /*
     * 1. İsimlendirme
     * 2. Fonksiyonlar
     * 3. SOLID 
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<TimeSheetEntry> timeSheetEntries = GetTimeSheetEntriesFromUser();

            BillCalculator billCalculator = new BillCalculator();
            NotificationService notificationService = new NotificationService(billCalculator);
            Simulator simulator = new Simulator(notificationService);

            simulator.SimuleEmailToAllCompanies(timeSheetEntries);
            ExtraPaymentOptions paymentOptions = new ExtraPaymentOptions();
            double extraBill = billCalculator.GetExtraPayment(timeSheetEntries, paymentOptions);
            ShowExtraPaymentInfo(extraBill);
        }

        private static void ShowExtraPaymentInfo(double extraBill)
        {
            Console.WriteLine("You will get paid $" + extraBill + " for your work.");
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }
        static List<TimeSheetEntry> GetTimeSheetEntriesFromUser()
        {
            string workDescription;
            string rawTimeWorked;
            double timeForWork;


            List<TimeSheetEntry> timeSheetEntries = new List<TimeSheetEntry>();

            do
            {
                Console.Write("Enter what you did: ");
                workDescription = Console.ReadLine();
                timeForWork = GetDoubleFromString();

                TimeSheetEntry timeSheetEntry = new TimeSheetEntry
                {
                    HoursWorked = timeForWork,
                    WorkDone = workDescription
                };
                timeSheetEntries.Add(timeSheetEntry);
                Console.Write("Do you want to enter more time (yes/no): ");

                string answer = Console.ReadLine();
                //eğer yes dışında bir cevap verirse:
                if (answer.ToLower() != "yes")
                {
                    //koleksiyonu döndür:
                    return timeSheetEntries;
                }



            } while (true);



        }
        static double GetDoubleFromString()
        {


            do
            {
                double timeForWork;
                Console.Write("How long did you do it for: ");
                string rawTimeWorked = Console.ReadLine();
                bool isParse = double.TryParse(rawTimeWorked, out timeForWork);
                if (!isParse)
                {

                    Console.WriteLine();
                    Console.WriteLine("Invalid number given");
                }
                else
                {
                    return timeForWork;
                }

            } while (true);


        }

    }
}
