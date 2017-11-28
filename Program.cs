using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human fred = new Human();
            Human george = new Human();
            
            fred.attack(george);
            
            Console.WriteLine(george.getHealth());
            
            Console.WriteLine();
            Console.WriteLine();
            
            Wizard gandalf = new Wizard();
            gandalf.fireball(fred);
            gandalf.heal();
            
            Ninja naruto = new Ninja();
            naruto.steal(gandalf);
            naruto.get_away();
            
            Samurai jack = new Samurai();
            jack.medidate();
            Samurai shigeru = new Samurai();
            Samurai yamada = new Samurai();
            shigeru.death_blow(yamada);
            Console.WriteLine(Samurai.howMany());
        }
    }

    public class Human
    {

        public int strength, intelligence, stealth, health;
        public string name;
        
        public Human()
        {
            initialize();
        }

        public Human(string name)
        {
            initialize();
            this.name = name;
        }

        public Human(int strength, int intelligence, int stealth, int health, string name)
        {
            this.strength = strength;
            this.intelligence = intelligence;
            this.stealth = stealth;
            this.health = health;
            this.name = name;
        }

        private void initialize()
        {
            strength = intelligence = stealth = 3;
            health = 100;
        }
        
        public int getHealth()
        {
            return health;
        }
        
        public void attack(Object h)
        {
            if(h is Human)
            {
                (h as Human).health -= 5 * strength;
            }
        }

    }

    public class Samurai : Human
    {
        
        private static int number;

        public Samurai() : base()
        {
            health = 200;
            number ++;
        }
        
        public void death_blow(Human h)
        {
            attack(h);
            if(h.health < 50) h.health = 0;
        }
        
        public void medidate()
        {
            health = 200;
        }
        
        public static int howMany()
        {
            return number;
        }
        
    }

    public class Wizard : Human
    {
        private static Random r = new Random();
        public Wizard() : base()
        {
            intelligence = 25;
            health = 50;
        }
        
        public void heal()
        {
            health += 10 * intelligence;
        }
        
        public void fireball(Human h)
        {
            h.health -= r.Next(20, 51);
        }

    }
    public class Ninja : Human
    {

        public Ninja() : base()
        {
            stealth = 175;
        }
        
        public void steal(Human h)
        {
            attack(h);
            health += 10;
        }
        
        public void get_away()
        {
            health -= 15;
        }
    }

}
