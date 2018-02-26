using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Challenge_13_WarCardGame
{
    public class Battle
    {
        private List<Card> _bounty;
        private StringBuilder _sb;

        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder();
        }

        public string performBattle(Player player1, Player player2)
        {
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);

            performEvaluation(player1, player2, player1Card, player2Card);
            return _sb.ToString();
        }

        public Card getCard(Player player)
        {

            //Getting one card from the player's deck. The Element at 0 gets the
            //card on top, or the first card in the deck.
            Card card = player.Cards.ElementAt(0);
            player.Cards.Remove(card);
            _bounty.Add(card);
            return card;
        }

        private void performEvaluation(Player player1, Player player2, Card card1, Card card2)
        {
            displayBattleCards(card1, card2);
            if (card1.CardValue() == card2.CardValue())
                war(player1, player2);
            if (card1.CardValue() > card2.CardValue())
               awardWinner(player1);
            else
               awardWinner(player2);
        }

        private void awardWinner(Player player)
        {
            if (_bounty.Count == 0) return;
            displayBountyCards();
            player.Cards.AddRange(_bounty);
            _bounty.Clear();

            _sb.Append("<br /><strong>");
            _sb.Append(player.Name);
            _sb.Append(" wins!</strong><br />");

        }

        private void war(Player player1, Player player2)
        {
            _sb.Append("<br/>*****WAR*****<br/>");

            getCard(player1);
            getCard(player1);
            getCard(player1);
            Card warCard1 = getCard(player1);

            getCard(player2);
            getCard(player2);
            getCard(player2);
            Card warCard2 = getCard(player2);

            performEvaluation(player1, player2, warCard1, warCard2);

        }

        private void displayBattleCards(Card card1, Card card2)
        {
            //string str0 = "<br/>Battle Cards: ";
            //string str1 = " of ";
            //string str2 = " verses ";

            //string displayBattleCards = string.Concat(str0, card1.Rank, str1, card1.Suit, str2, card2.Rank, str1, card2.Suit);
            //return displayBattleCards;
            //Didn't work, even with void changed to string...

            _sb.Append("<br />Battle Cards: ");
            _sb.Append(card1.Rank);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" versus ");
            _sb.Append(card2.Rank);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);
        }

        private void displayBountyCards()
        {
            _sb.Append("<br />Bounty . . .");

            foreach (var card in _bounty)
            {
                _sb.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;");
                _sb.Append(card.Rank);
                _sb.Append(" of ");
                _sb.Append(card.Suit);
            }

        }
    }
}