namespace ConsoleApp1.Models
{
    public class Candidate : Person
    {
        public string DesiredTitle { get; set; }
        public string PositionDescription { get; set; }
        public string DesiredSalary { get; set; }
        
        public override string ToString()
        {
            return
                $"Hello, I am {FullName} I want to be a {DesiredTitle} ({PositionDescription}) with a salary from {DesiredSalary}";
        }
    }
}