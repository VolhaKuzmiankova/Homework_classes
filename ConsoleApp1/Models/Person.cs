using System;

namespace ConsoleApp1.Models
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public abstract override string ToString();
    }
}