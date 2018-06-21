using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck_of_Cards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player mailman = new Player();

            Deck deck = new Deck();
            
            mailman.Draw(deck);
        }
    }
}
