using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_13_WarCardGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        //This is the Player constructor
        public Player()
        {
            //Error when running program because there where no Cards in Player class:
            //Error from dealCard method in Deck class: player.Cards.Add(card);
            //This makes a new list of cards the player can use.
            //Whenever you create a new player, you have to 'new up' this list of cards.
            Cards = new List<Card>();

        }
    }
}