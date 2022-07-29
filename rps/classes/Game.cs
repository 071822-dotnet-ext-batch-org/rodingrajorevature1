using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rps
{
    public class Game
    {
        public static void Start()
        {
            Game.WelcomeMessage();
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Rock! Paper! Scissors!");
        }
    }
}