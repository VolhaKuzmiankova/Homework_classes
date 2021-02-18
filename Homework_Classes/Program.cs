using System;
using ConsoleApp1.Factories;
using ConsoleApp1.Models;
using ConsoleApp1.Printers;
using ConsoleApp1.Reports;
using ConsoleApp1.Utils;


namespace ConsoleApp1
{
    class Program
    {

        private static readonly int MAX_CANDIDATES_COUNT = 15;
        private static readonly int MIN_CANDIDATES_COUNT = 5;
        private static readonly int MAX_EMPLOYEES_COUNT = 10;
        
        static void Main(string[] args)
        {
            var factory = new UserFactory();
            var candidates = factory.GetPeople(UserType.CANDIDATE, RandomUtil.GetRandomInt(MIN_CANDIDATES_COUNT, MAX_CANDIDATES_COUNT));
            var employees = factory.GetPeople(UserType.EMPLOYEE, RandomUtil.GetRandomInt(max: MAX_EMPLOYEES_COUNT));

            var printer = new ConsolePrinter();
            foreach (var candidate in candidates)
            {
                printer.Display(candidate);
            }

            Console.WriteLine();
            foreach (var employee in employees)
            {
                printer.Display(employee);
            }

            var employeeGenerator = new EmployeeReportGenerator();
            employeeGenerator.Report(employees);
            Console.WriteLine();
            var candidateReportGenerator = new CandidateReportGenerator();
            candidateReportGenerator.Report(candidates);
        }
    }
}