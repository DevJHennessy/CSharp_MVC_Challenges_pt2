using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_13_WarCardGame
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {

            //This is for testing, to make work, first switch _deck from private to
            //public in the Deck class.
            //Deck deck = new Deck();
            //foreach (var card in deck._deck)
            //{
            //    resultLabel.Text += "<br />" + card.Rank + " of " + card.Suit;
            //}

            //Creating a new Game instance named game.
            Game game = new Game("Player One", "Player Two");
            //Using the game variable created above to call the Play method:
            resultLabel.Text = game.Play();

        }
    }
}