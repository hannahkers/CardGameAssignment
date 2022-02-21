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
        public Deck fiftyTwoCardDeck = new Deck(new List<string>() { "Apples", "Oranges", "Bananas", "Pears" }, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });

        public void PrintDeck()
        {
            fiftyTwoCardDeck.ShowCards();

        }

       
        List<Card> Shuffle(List<Card> unshuffled)
        {
            Random random = new Random();
            return unshuffled.OrderBy(a => random.Next()).ToList();
        }
        public void AppleOranges()
        {
            fiftyTwoCardDeck.cards = Shuffle(fiftyTwoCardDeck.cards);
            int guess = 0;
            int target = 5;
            string Input = "";
            Random RandomNumber = new Random();

            //statements to run the game
            target = RandomNumber.Next(2) + 1;

            Print("The first card drawn is:");
            Print($"{target}.");

            Print("Will the next card be the same suit or a different one?");
            Print("Enter 1 for same, 2 for different:");
            Input = ReadLine();
            if (int.TryParse(Input, out guess))
            {
                if (guess == target)
                {
                    //match - congratulations!    
                    Print("Congratulations! You guessed " + guess + " and I was thinking of " + target + ".");
                    AppleOranges();
                }
                else
                {
                    //no match - try again
                    Print("Sorry. You guessed " + guess + ". I was thinking of " + target + ". Try again!");
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


        public void HigherLower()
        {
            fiftyTwoCardDeck.cards = Shuffle(fiftyTwoCardDeck.cards);
            int guess = 0;
            int target = 5;
            int targetIndex = 0;
            string input = "";
            Random randomNumber = new Random();
            targetIndex = randomNumber.Next(0,fiftyTwoCardDeck.cards.Count);
            target = fiftyTwoCardDeck.cards[targetIndex].Value;

            Print("The first card drawn is:");
            Print($"{target} of {fiftyTwoCardDeck.cards[targetIndex].Suit}.");

            Print("Will the next card be a higher value or lower value?");
            Print("Enter 1 for higher, 2 for lower:");
            input = ReadLine();
            int.TryParse(input, out guess);
            int followIndex = 0;
            followIndex = randomNumber.Next(0, fiftyTwoCardDeck.cards.Count);
            int followValue = fiftyTwoCardDeck.cards[followIndex].Value;
            if (guess == 1)
            {
                if (followValue > target)
                {
                    Print("Correct");
                    Print($"The new card is {followValue} of {fiftyTwoCardDeck.cards[followIndex].Suit}");
                }
                else
                {
                    Print("Incorrect");
                    Print($"The new card is {followValue} of {fiftyTwoCardDeck.cards[followIndex].Suit}");
                }

            }
            if (guess == 2)
            {
                if (target > followValue)
                {
                    Print("Correct");
                    Print($"The new card is {followValue} of {fiftyTwoCardDeck.cards[followIndex].Suit}");
                }
                else
                {
                    Print("Incorrect");
                    Print($"The new card is {followValue} of {fiftyTwoCardDeck.cards[followIndex].Suit}");
                }

            }
            else
            {
                Print("Please choose a valid number");

            }
            
        }

       
    }
}
