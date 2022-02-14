using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CardGameAssignment.Utility;

namespace CardGameAssignment
{
    class Game
    {
        public string instructions;
        public int numOfPlayers;
        public Deck fiftyTwoCardDeck = new Deck(new List<string>() { "Apples", "Oranges", "Bananas", "Pears" }, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
        
        public void ShowInstructions()
        {

        }
        List<Card> Shuffle(List<Card> unshuffled)
        {
            Random random = new Random();
            return unshuffled.OrderBy(a => random.Next()).ToList();
        }
        public void AppleOranges()
        {
            fiftyTwoCardDeck.cards = Shuffle(fiftyTwoCardDeck.cards);
            int Guess = 0;
            int Target = 5;
            string Input = "";
            Random RandomNumber = new Random();

            //statements to run the game
            Target = RandomNumber.Next(2) + 1;

            Print("The first card drawn is:");
            Print($"{Target}.");

            Print("Will the next card be the same suit or a different one?");
            Print("Enter 1 for same, 2 for different:");
            Input = ReadLine();
            if (int.TryParse(Input, out Guess))
            {
                if (Guess == Target)
                {
                    //match - congratulations!    
                    Print("Congratulations! You guessed " + Guess + " and the number I was thinking of was " + Target + ".");
                    AppleOranges();
                }
                else
                {
                    //no match - try again
                    Print("Sorry. You guessed " + Guess + ". The number I was thinking of was " + Target + ". Try again!");
                    AppleOranges();
                }
            }
            else
            {
                Print("please enter a valid number.");
                Pause();
                AppleOranges();
            }
            ReadKey();


           


            
        }

       
    }
}
