using System;
using System.Collections.Generic;
using Bogus;
using ConsoleApp1.Models;
using Person = ConsoleApp1.Models.Person;

namespace ConsoleApp1.Factories
{
    public class UserFactory
    {
        public List<Candidate> GetCandidates(int userCount = 1)
        {
            return new Faker<Candidate>()
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.DesiredTitle, f => f.Name.JobTitle())
                .RuleFor(u => u.PositionDescription, f => f.Name.JobDescriptor())
                .RuleFor(u => u.DesiredSalary, f => $"{f.Finance.Amount()} {f.Finance.Currency().Code}")
                .Generate(userCount);
        }
        
        public List<Employee> GetEmployees(int userCount = 1)
        {
            var companyFaker = new CompanyFaker();
            var jobFaker = new JobFaker();
            
            return new Faker<Employee>()
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Job, () => jobFaker.GetJob())
                .RuleFor(u => u.Company, () => companyFaker.GetCompany())
                .Generate(userCount);
        }

        public List<Person> GetPeople(UserType type = UserType.CANDIDATE, int count = 10)
        {
            return type switch
            {
                UserType.CANDIDATE => new List<Person>(GetCandidates(count)),
                UserType.EMPLOYEE => new List<Person>(GetEmployees(count)),
                _ => throw new ArgumentException($"Not supported type {type}")
            };
        }
    }
}