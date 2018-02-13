using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace Challenge_11_SimpleDarts
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        //The Dart has to pass in Random, so this is made:
        private Random _random;

        //The constructor: The okButton click event will pass in two names for player1 and 2.
        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player();
            _player1.Name = player1Name;

            _player2 = new Player();
            _player2.Name = player2Name;

            //To use for calling the constrctor.
            _random = new Random();
        }

        public string Play()
        {
            while (_player1.Score < 300 && _player2.Score < 300)
            {
                playRound(_player1);
                playRound(_player2);
            }

            return displayResults();
        }

        private string displayResults()
        {
            string result = String.Format("{0} {1}<br />{2}: {3}", 
                _player1.Name, 
                _player1.Score, 
                _player2.Name,
                _player2.Score);

            //The ? and :
            //This is conditional operator and returns one of two values depending on the 
            //value of a Boolean explression. In this case, if player 1's score is greater
            //than player 2's score, then display player 1's name, else the condition is false and
            //dislay player 2's name.
            return result += "<br />Winner: " + 
                (_player1.Score > _player2.Score ? _player1.Name : _player2.Name);
        }

        //This is for throwing three darts: You have to create a reference to the darts 
        //assembly.
        private void playRound(Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                Dart dart = new Dart(_random);
                dart.Throw();
                Score.ScoreDart(player, dart);
            }
        }
    }
}