using Bogus;
using ConsoleApp1.Models;

namespace ConsoleApp1.Factories
{
    public class JobFaker
    {
        public Job GetJob()
        {
            return new Faker<Job>()
                .RuleFor(j => j.JobTitle, f => f.Name.JobTitle())
                .RuleFor(j => j.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(j => j.JobSalary, f => $"{f.Finance.Amount()} {f.Finance.Currency().Code}")
                .Generate();
        }
    }
}