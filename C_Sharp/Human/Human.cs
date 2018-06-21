namespace Human
{
    public class Human
    {
        public string name;
        public Human(string x){
            name = x;
        }
        
        public int strength = 3;

        public int intellegence = 3;

        public int dexterity = 3;

        public int health = 100;

        public Human(string x, int str, int intel, int dext, int heal){
            name = x;
            strength = str;
            intellegence = intel;
            dexterity = dext;
            health = heal;
        }

        public void Attack(object obj){
            Human target;
            if(obj is Human){
                target = obj as Human;
            }
            else
                return;

            int thisDamage = strength * 5;
            System.Console.WriteLine($"{this.name} is attacking {target.name} for {thisDamage} health!");
           
            if(target.health - thisDamage >= 0){
                target.health -= thisDamage;
            }
            System.Console.WriteLine($"{target.name} now has {target.health} health");
        }
    }
}






//Create a base Human class with 5 attr: name, strength, intelligence, dexterity, & health

//Give default value of 3 to strength, intellegence, & dexterity; health default = 100

//When object is constructed from this class it should have the ability to pass a name

//Create additional constructor that accepts 5 parameters, so we can set custom values for every field

// Add new method called attack, when invoked - attack another human object that is passed as a parameter.
//the damage should be 5* strength( 5 pts of damage to the attacked, for each 1 pt of strength of the attacker)