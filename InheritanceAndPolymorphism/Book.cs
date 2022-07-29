using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Book : Media
    {
        public Book(string title, string author) : base(title, author)
        {
            this.Title = title;
            this.Creator = author;
        }

        public override string GetCreator()
        {
            return $"The author of this book is {this.Creator}";
        }
        
    }
}