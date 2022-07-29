using System;

namespace rps
{
    public class Player {
        public Player(string fname, string lname)
        {
            this.Fname = fname;
            this.Lname = lname;
        }

        public string Fname { get; set; }
        public string Lname { get; set; }

        private int wins;

        public int Wins
        {
            get { return this.wins; }
            set { this.wins++; }
        }

        private int losses;

        public int Losses
        {
            get { return this.losses; }
            set { this.losses++; }
        }
    }
}