using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CardGameAssignment
{
    class Card
    {
        public int Value;
        public string Suit;
        
        public Card(string n, int x)
        {
            Suit = n;
            Value = x;
        }



        //string[] Suits = { "Apples", "Oranges" };
       // int deckSize = 26;

    }
}