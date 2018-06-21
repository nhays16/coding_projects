namespace Human{
    public class Ninja : Human
    {

        public Ninja(string x) : base(x)
        {
            dexterity = 175;
        }

        public void Steal(object obj){
            Human target;
            if(obj is Human){
                target = obj as Human;
            }
            else
                return;
            
            if(target != null){
                Attack(target);
                health += 10;
            }

            System.Console.WriteLine($"{this.name}'s health is now {health}");
        }

        public void Get_Away(){
            health -= 15;
            System.Console.WriteLine($"{this.name} has ran away and now has a health of {health}");
            
        }
    }
}