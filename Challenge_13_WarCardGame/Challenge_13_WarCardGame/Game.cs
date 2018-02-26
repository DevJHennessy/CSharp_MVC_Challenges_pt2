using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_13_WarCardGame
{
    public class Game
    {
        //Creating _player1 and _player2 to be used  outside of the constructor:
        private Player _player1;
        private Player _player2;


        //Creating two instances of player and passing in two names:
        //This is the constructor for the Game class:
        public Game (string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };

        }

        //Making a new helper method called Play to start the play of the game by
        //dealing the cards to player1 and player2.
        public string Play()
        {
            //Making a new instance of the Deck, this will give the cards to the Game.
            Deck deck = new Deck();

            //Dealing to player1 and player2, and this will return a string:
            string result = "<h3>Dealing cards for Round...</h3>";
            result += deck.Deal(_player1, _player2);

            result += "<h3>Begin battle!</h3>";

            result += Round();

            ////Determine winner of game:
            result += determineWinner();
            return result;

        }

        private string Round()
        {
            string result = "";
            int round = 0;

            while (_player1.Cards.Count != 0 && _player2.Cards.Count != 0)
            {

                Battle battle = new Battle();
                result += battle.performBattle(_player1, _player2);

                round++;
                if (round > 20)
                    break;

            }

            return result;
        }



        //This is what the player will actually get:
        private string determineWinner()
        {
            string result = "";
            if (_player1.Cards.Count > _player2.Cards.Count)
                result += "<br /><span style='color: purple; font-weight: 600;'>Player 1 wins!</span>";
            else
                result += "<br /><span style='color: green; font-weight: 600;'>Player 2 wins!";

            result += "<br /><span style='color: purple; font-weight: 600;'>Player 1: " + _player1.Cards.Count + "</span><br/><span style='color: green; font-weight: 600;'> Player 2: " + _player2.Cards.Count + "</span>";
            return result;
        }

    }
}