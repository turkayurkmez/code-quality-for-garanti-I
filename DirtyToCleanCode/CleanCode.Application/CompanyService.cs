using CleanCode.Entities;

namespace CleanCode.Application
{
    public class CompanyService
    {
        public List<Company> GetCompanies()
        {
            return new List<Company>()
            {
                new(){ Name= "acme", HourlyPrice = 150},
                new(){ Name= "abc", HourlyPrice = 125},

            };
        }
    }
}
