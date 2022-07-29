using System;
using System.Collections.Generic;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Animal Farm", "George Orwell");
            Console.WriteLine(book.GetTitle());
            Console.WriteLine(book.GetCreator());
        }
    }
}