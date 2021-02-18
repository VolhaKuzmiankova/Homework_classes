using Bogus;
using ConsoleApp1.Models;

namespace ConsoleApp1.Factories
{
    public class CompanyFaker
    {
        public Company GetCompany()
        {
            return new Faker<Company>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .Generate();
        }
    }
}