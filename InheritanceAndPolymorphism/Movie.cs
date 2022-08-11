using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Movie : Media
    {
        public string? Length { get; set; }
        public List<string> Actors = new List<string>();
        public string? Plot { get; set; }
        public string? Rating { get; set; }

        public Movie(string title, string director) : base(title, director)
        {
            this.Title = title;
            this.Creator = director;
        }

        public override string GetCreator()
        {
            return $"The director of this movie is {this.Creator}";
        }
    }


}