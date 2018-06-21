namespace Human{

    public class Samurai : Human{

        public Samurai(string x) : base(x)
        {
            health = 200;
        }

        public void Death_Blow(object obj){
            Human target;
            if(obj is Human){
                target = obj as Human;
            }
            else
                return;

            if(target != null){
                if(target.health < 50){
                    target.health = 0;
                    System.Console.WriteLine($"{target.name} was attacked by {this.name} and now has 0 health");
                }
            }
        }

        public void Meditate(){
            health = 200;
            System.Console.WriteLine($"{this.name} now has full health again");
        }

    }
}