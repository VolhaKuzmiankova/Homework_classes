using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Reports
{
    public class CandidateReportGenerator : IReportGenerator
    {
        public void Report(List<Person> candidates)
            {
                var castedCandidates = candidates.OfType<Candidate>();
                var sortedCandidates = castedCandidates.OrderBy(candidate => candidate.DesiredTitle)
                    .ThenBy(candidate => candidate.DesiredSalary).ToList();
                Console.WriteLine("UserId || Users Full Name || JobTittle || Salary");
                foreach (var candidate in sortedCandidates)
                {
                    Console.WriteLine(
                        $"{candidate.Id} || {candidate.FullName} || {candidate.DesiredTitle} || {candidate.DesiredSalary}");
                }
            }
        }
    }
