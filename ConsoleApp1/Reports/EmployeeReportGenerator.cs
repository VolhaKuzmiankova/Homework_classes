using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Reports
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        public void Report(List<Person> employees)
        {
            var castedEmployees  = employees.OfType<Employee>();
            var sortedEmployees = castedEmployees.OrderByDescending(employee => employee.Company.Name)
                .ThenByDescending(employee => employee.Salary).ToList();
            Console.WriteLine("UserId || Company Name || Users Full Name || Salary");
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"{employee.Id} || {employee.Company.Name} || {employee.FullName} || {employee.Salary}");
            }
        }
    }
}