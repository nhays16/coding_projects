using System;
namespace Human{

    public class Wizard : Human
    {

        public Wizard(string x) : base(x)
        {
            health = 50;
            intellegence = 25;
        }

        public void Fireball(object obj){
            Human target;
            if(obj is Human){
                target = obj as Human;
            }
            else
                return;

            if(target != null){
                Random rand = new Random();
                int thisRand = rand.Next(20,51);
                System.Console.WriteLine($"{this.name} is attacking {target.name} for {thisRand} health!");

                if(target.health - thisRand >= 0){
                    target.health -= thisRand;
                }
                System.Console.WriteLine($"{target.name} now has {target.health} health");
            }
        }

        public void Heal(){
            health += 10 * intellegence;
            System.Console.WriteLine($"{this.name} now has health of {health}");
        }
    }
}