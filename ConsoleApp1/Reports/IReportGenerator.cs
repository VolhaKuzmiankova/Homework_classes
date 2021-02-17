using System.Collections.Generic;
using ConsoleApp1.Models;

namespace ConsoleApp1.Reports
{
    public interface IReportGenerator
    {
        void Report(List<Person> people);
    }
}