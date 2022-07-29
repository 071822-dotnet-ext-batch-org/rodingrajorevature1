using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class Media
    {
        public string Title;
        public string Creator;
        public Media(string title, string creator)
        {
            this.Title = title;
            this.Creator = creator;
        }

        public string GetTitle()
        {
            return $"The title is {this.Title}";
        }

        public abstract string GetCreator();
    }


}