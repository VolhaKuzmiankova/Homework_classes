namespace ConsoleApp1.Models
{
    public class Employee : Person

    {
        public string Title { get; set; }
        public string TitleDescription { get; set; }
        public string Salary { get; set; }
        public Company Company { get; set; }

        public override string ToString()
        {
            return
                $"Hello, I am {FullName}, {Title} in {Company.Name} ({Company.Country}, {Company.City}, {Company.Address}) and my salary {Salary}";
        }
    }
}