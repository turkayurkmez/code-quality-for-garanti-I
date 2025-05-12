using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class ReportGenerator
    {
        private string excelFilePath;
       
        public ReportGenerator(string excelFilePath)
        {
            //if (!string.IsNullOrEmpty(excelFilePath))
            //{
            //    if (File.Exists(excelFilePath))
            //    {
            //        if (isAvailable)
            //        {
            //           this.excelFilePath = excelFilePath;
            //        }
            //        else
            //        {
            //            throw new Exception("Excel formatı rapor için uygun değil");
            //        }
            //    }
            //}

            //if (string.IsNullOrEmpty(excelFilePath))
            //{
            //    throw new ArgumentNullException(nameof(excelFilePath), "Parametre boş olamaz!");
            //}

            ArgumentNullException.ThrowIfNullOrEmpty(nameof(excelFilePath));

            checkFileIsValid(excelFilePath);
            this.excelFilePath = excelFilePath;

        

        }

        void checkFileIsValid(string filePath) {
            if (!File.Exists(excelFilePath))
            {
                throw new FileNotFoundException($"{excelFilePath} adresinde dosya bulunamadı!");
            }

            if (!isFormatAvaliable(filePath))
            {
                throw new Exception("Excel formatı rapor için uygun değil");

            }
        }

        private bool isFormatAvaliable(string filePath)
        {
            return true;
        }

        public void GenerateReport(ReportOptions options)
        {
            
        }
    }
}
