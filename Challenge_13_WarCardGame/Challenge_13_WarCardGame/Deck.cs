using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Challenge_13_WarCardGame
{
    public class Deck
    {

        //The _deck variable is created with the List<Card> data type. It's not
        //assigned anything here. The List allows you to add and remove cards later
        //on.
        //This works too: private List<Card> _deck = new List<Card>();
        private List<Card> _deck;

        //Created a new variable _random that is Random class data type.
        //This works too: private Random _random = new Random();
        private Random _random;

        //Setting up a string builder to use later on
        //This works too: private StringBuilder _sb = new StringBuilder();
        private StringBuilder _sb;

        //Methods that have the same name as the class are called constructors and 
        //don't have a return type, which means it can't be void, int, and so on.
        public Deck()
        {
            //The variable _deck is assigned a new instance of List<Card> and then 
            //two string arrays are put in the List<Card>. Is it a best practice
            //to assign the variable in the Constructor? Seems that way.
            _deck = new List<Card>();
            _random = new Random();
            //assigning _sb to a new StringBuilder method.
            _sb = new StringBuilder();

            string[] suits = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
            string[] ranks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            //You can use a forearch statement with arrays as you can with collections.
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    //You want to add a new card to the deck: To do this, you can
                    //use the Add helper method and input a new instance of the Card 
                    //class. You fill in the members of the Card class from there and
                    //assign them to the variables of the foreach statements.
                    _deck.Add(new Card() { Suit = suit, Rank = rank });
                }
            }

        }

        //Passing in the number of players that will be dealt, in this case two.
        //why is this method public and not private?
        //Changing public void to public string to return the StringBuilder
        public string Deal(Player player1, Player player2)
        {
            while (_deck.Count > 0)
            {
                //While the deck count is greater than zero
                //Deal a random card to each player: Created a method to pass in the
                //cards to the two players.
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        //A method to help deal the cards, you pass in one Player class and give it a new
        //variable name.
        private void dealCard(Player player)
        {
            //Creating a new card and assigning a random element in the _deck for the
            //count of the deck.
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            //adding a card to the players hand.
            player.Cards.Add(card);
            //Removing the card from the _deck once it has be dealt.
            _deck.Remove(card);

            //Might be a better way to approach logging?
            //Crossing-cutting concerns, things that you will need potentially 
            //across all of your classes.

            //StringBuilder allows you to make changes to string efficiently,
            //changing their size, such as dealing cards from the _deck to the player.
            //How to show the data in the array.
            _sb.Append("<br />");
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Rank);
            _sb.Append(" of ");
            _sb.Append(card.Suit);
        }
    }
}