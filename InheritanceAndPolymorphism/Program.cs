using System;
using System.Collections.Generic;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookSummary = "An allegory of authoritarianism with animals";
            Book book = new Book("Animal Farm", "George Orwell", 200, bookSummary);
            Console.WriteLine(book.GetTitle());
            Console.WriteLine(book.GetCreator());
            Console.WriteLine($"It is {book.Pages} pages long");
            Console.WriteLine($"The book is about {book.Summary}\n");

            Movie movie = new Movie("The Matrix", "The Wachowskis");
            movie.Length = "2 hours";
            movie.Actors.Add("Keanu Reeves");
            movie.Actors.Add("Carrie-Anne Moss");
            movie.Actors.Add("Laurence Fishburne");
            movie.Plot = "Hackers break reality";
            movie.Rating = "R";
            Console.WriteLine(movie.GetTitle());
            Console.WriteLine(movie.GetCreator());
            Console.WriteLine($"It is {movie.Length} long");
            Console.WriteLine($"The movie stars:");
            foreach (string actor in movie.Actors) 
            {
                Console.WriteLine(actor);
            }
            Console.WriteLine($"Plot summary: {movie.Plot}");
            Console.WriteLine($"It is rated {movie.Rating}");
        }
    }
}