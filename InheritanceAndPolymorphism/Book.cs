using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Book : Media
    {
        public int Pages { get; set; }
        public string Summary { get; set; }

        public Book(string title, string author, int pages, string summary) : base(title, author)
        {
            this.Title = title;
            this.Creator = author;
            this.Pages = pages;
            this.Summary = summary;
        }

        public override string GetCreator()
        {
            return $"The author of this book is {this.Creator}";
        }
        
    }
}