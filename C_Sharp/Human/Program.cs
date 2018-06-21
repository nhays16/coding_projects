using System;
using System.Collections.Generic;
using System.Linq;

namespace Human
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human mrSmith = new Human("Mr Smith");
            Human mailman = new Human("Mailman");
            mrSmith.Attack(mailman);

            Wizard White = new Wizard("White");
            Ninja Black = new Ninja("Black");
            Samurai Red = new Samurai("Red");

            Red.Death_Blow(White);
            White.Fireball(Black);
            White.Heal();
            Black.Steal(Red);
            Black.Get_Away();
            Red.Meditate();
        }
    }
}
