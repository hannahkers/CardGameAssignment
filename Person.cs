using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameAssignment
{
    class Person
    {
        int score = 0;
        public string playerName;
        public List<Card> playerHand = new List<Card>();

        public int Score { get => score; set => score = value; }
    }
}
