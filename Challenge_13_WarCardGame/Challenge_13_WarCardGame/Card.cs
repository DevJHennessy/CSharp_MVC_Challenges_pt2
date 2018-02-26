using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_13_WarCardGame
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        //To actually get the value of the cards to compare:

        public int CardValue()
        {
            //This initializes the value at 0.
            int value = 0;

            //The switch keyword allows you to change the value, in this case the
            //face cards to a numberic value as an integer.
            switch (this.Rank)
            {

                case "Jack":
                    value = 11;
                    break;
                case "Queen":
                    value = 12;
                    break;
                case "King":
                    value = 13;
                    break;
                case "Ace":
                    value = 14;
                    break;
                //The default establishes the rest of the card value, parsed from
                //their string values to integer values.
                default:
                    value = int.Parse(this.Rank);
                    break;
            }
            return value;

        }

     
    }
}