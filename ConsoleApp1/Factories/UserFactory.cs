using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            var fakeCompany = new Faker<Company>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Address, f => f.Address.FullAddress());

            return new Faker<Employee>()
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Title, f => f.Name.JobTitle())
                .RuleFor(u => u.TitleDescription, f => f.Name.JobDescriptor())
                .RuleFor(u => u.Salary, f => $"{f.Finance.Amount()} {f.Finance.Currency().Code}")
                .RuleFor(u => u.Company, () => fakeCompany )
                .Generate(userCount);
        }

        public List<Person> GetPeople(string type = "candidate", int count = 10)
        {
            return type.ToLower() switch
            {
                "candidate" => new List<Person>(GetCandidates(count)),
                "employee" => new List<Person>(GetEmployees(count)),
                _ => throw new ArgumentException($"Not supported type {type}")
            };
        }
    }
}