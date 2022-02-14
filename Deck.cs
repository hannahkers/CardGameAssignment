using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CardGameAssignment.Utility;

namespace CardGameAssignment
{
    class Deck
    {
      
        public List<Card> cards = new List<Card>();

        public Deck(List<string> s, List<int> v)
        {
            foreach (var suit in s)
            {
                foreach (var value in v)
                {
                    Card card = new Card(suit, value);
                    cards.Add(card);
                }
            }
        }

        public void ShowCards()
        {
            foreach (var card in cards)
            {
                Print($"{card.Value} of {card.Suit}.{Environment.NewLine}");
            }
        }

    }
}
