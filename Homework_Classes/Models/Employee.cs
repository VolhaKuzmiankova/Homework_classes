namespace ConsoleApp1.Models
{
    public class Employee : Person
    {
        public Job Job { get; set; }
        public Company Company { get; set; }

        public override string ToString()
        {
            return
                $"Hello, I am {FullName}, {Job.JobTitle} in {Company.Name} ({Company.Country}, {Company.City}, {Company.Address}) and my salary {Job.JobSalary}";
        }
    }
}