using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_08_Casino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Display the random images on PageLoad:
                string[] pull = new string[] { getRandomImage(), getRandomImage(), getRandomImage() };
                displayImages(pull);
                ViewState.Add("PlayersMoney", 100);
                displayPlayersMoney();
            }

        }

        private void displayPlayersMoney()
        {
            moneyLabel.Text = String.Format("Player's Money: {0:C}", ViewState["PlayersMoney"]);
        }

        protected void pullButton_Click(object sender, EventArgs e)
        {
            //When someone clicks button, display random image in Image1, Image2, Image3.
            int bet = 0;
            if (!int.TryParse(betTextBox.Text, out bet)) return;
            int winnings = pullLever(bet);

            displayResult(bet, winnings);
            adjustPlayersMoney(bet, winnings);
            displayPlayersMoney();

        }

        private void adjustPlayersMoney(int bet, int winnings)
        {
            int playersMoney = int.Parse(ViewState["PlayersMoney"].ToString());
            playersMoney -= bet;
            playersMoney += winnings;
            ViewState["PlayersMoney"] = playersMoney;
        }

        private void displayResult(int bet, int winnings)
        {
            if (winnings > 0)
            {
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winnings);
            }
            else
            {
                resultLabel.Text = String.Format("Sorry you lost {0:C}. Better luck next time.", bet);
            }
        }


        private int pullLever(int bet)
        {
            string[] pull = new string[] { getRandomImage(), getRandomImage(), getRandomImage() };
            displayImages(pull);

            int multiplier = evaluateSpin(pull);
            return bet * multiplier;
        }

        private int evaluateSpin(string[] pull)
        {
            //If there's one bar, then return 0.
            if (isBar(pull)) return 0;


            //If there's three 7's, then return 100.
            if (isJackPot(pull)) return 100;

            //If there's one or more cherries, return 2,3,4.
            int multplier = 0;
            if (isWinner(pull, out multplier)) return multplier;

            //For all other scenarios:
            return 0;


        }


        private bool isBar(string[] pull)
        {
            if (pull[0] == "Bar" || pull[1] == "Bar" || pull[2] == "Bar")
                return true;
            else
               return false;
        }

        private bool isJackPot(string[] pull)
        {
            if (pull[0] == "Seven" && pull[1] == "Seven" && pull[2] == "Seven")
                return true;
            else
                return false;
        }

        private bool isWinner(string[] pull, out int multplier)
        {
            multplier = determineMultiplier(pull);
            if (multplier > 0) return true;
            return false;
        }

        private int determineMultiplier(string[] pull)
        {
            int cherryCount = determineCherryCount(pull);
            if (cherryCount == 1) return 2;
            if (cherryCount == 2) return 3;
            if (cherryCount == 3) return 4;
            return 0;

        }

        private int determineCherryCount(string[] pull)
        {
            int cherryCount = 0;
            if (pull[0] == "Cherry") cherryCount++;
            if (pull[1] == "Cherry") cherryCount++;
            if (pull[2] == "Cherry") cherryCount++;
            return cherryCount;
        }


        private void displayImages(string[] pull)
        {
            Image1.ImageUrl = "/Images/" + pull[0] + ".png";
            Image2.ImageUrl = "/Images/" + pull[1] + ".png";
            Image3.ImageUrl = "/Images/" + pull[2] + ".png";

        }

        private string getRandomImage()
        {
            string[] img = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermellon" };
            return img[random.Next(11)];
        }

    }
}