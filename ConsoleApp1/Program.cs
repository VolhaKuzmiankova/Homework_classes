using System;
using ConsoleApp1.Factories;
using ConsoleApp1.Printers;
using ConsoleApp1.Reports;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int count = rnd.Next(20);
            
            var factory = new UserFactory();
            var candidates = factory.GetPeople("candidate", count);
            var employees = factory.GetPeople("employee", count);

            IPrinter printer = new ConsolePrinter();
            foreach (var candidate in candidates)
            {
                printer.Display(candidate);
            }
            Console.WriteLine();
            foreach (var employee in employees)
            {
                printer.Display(employee);
                
            }

            IReportGenerator employeeGenerator = new EmployeeReportGenerator();
            employeeGenerator.Report(employees);
            
            IReportGenerator candidateReportGenerator = new CandidateReportGenerator();
            candidateReportGenerator.Report(candidates);

        }
    }
}