using System;
using ConsoleApp1.Models;

namespace ConsoleApp1.Printers
{
    public class ConsolePrinter : IPrinter
    {
        public void Display(Person person)
        {
            Console.WriteLine(person);
        }
    }
}