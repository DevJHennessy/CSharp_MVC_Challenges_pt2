using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_10_HeroMonster
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();

            hero.Name = "The Mighty Steelheart";
            hero.Health = 100;
            hero.DamageMaximum = 25;
            hero.AttackBonus = false;

            Character monster = new Character();

            monster.Name = "The Vile Squasher";
            monster.Health = 100;
            monster.DamageMaximum = 22;
            monster.AttackBonus = true;


            Dice dice = new Dice();

            //Bonus attack:
            if (hero.AttackBonus)
            {
                monster.HitForLoss(hero.Attack(dice));
            }
            if (monster.AttackBonus)
            {
                hero.HitForLoss(monster.Attack(dice));
            }

            while (hero.Health > 0 && monster.Health > 0)
            {

                monster.HitForLoss(hero.Attack(dice));
                hero.HitForLoss(monster.Attack(dice));

                showHealth(hero);
                showHealth(monster);

                /*Alternative Code:
                int damage = hero.Attack(dice);
                monster.HitForLoss(damage);

                damage = monster.Attack(dice);
                hero.HitForLoss(damage);

                showHealth(hero);
                showHealth(monster);
                */
            }

            displayResult(hero, monster);


            //showHealth(hero);
            //showHealth(monster);

            /* Alternate Code:
            int opponent1 = hero.Health;
            int opponent2 = monster.Health;
            */

            //Alternative code:
            //displayResult(opponent1, opponent2);

        }

        /* Alternate Code:
        private void displayResult(int opponent1, int opponent2)
        {
            if (opponent1 <= 0)
                resultLabel.Text += "<h3>Monster wins!</h3>";
            else if (opponent2 <= 0)
                resultLabel.Text += "<h3>Hero wins!</h3>";
            else
                resultLabel.Text += "<h3>They are both losers!</h3>";
        }
        */

        
        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text += String.Format("\r\n{0} and {1} slew each other. They are both losers!", opponent1.Name, opponent2.Name);
            else if (opponent2.Health <= 0)
                resultLabel.Text += String.Format("\r\n{0} has been slain. {1} wins!", opponent2.Name, opponent1.Name);
            else
                resultLabel.Text += String.Format("\r\n{0} has been slain. {1} wins!", opponent1.Name, opponent2.Name);
        }
         

        private void showHealth(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3}</p>", character.Name, character.Health, character.DamageMaximum.ToString(), character.AttackBonus.ToString());  
        }
    }


    class Character
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            //int damage = random.Next(this.DamageMaximum);
            //return damage;
            //dice.Sides = this.DamageMaximum;
            //return dice.Roll();
            dice.Sides = this.DamageMaximum;
            return dice.Roll();
        }

        public void HitForLoss(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        Random random = new Random();

        public int Sides { get; set; }

        public int Roll()
        {
            //int roll = random.Next(this.Sides);
            //return roll;
            return random.Next(this.Sides);
        }
    }


}