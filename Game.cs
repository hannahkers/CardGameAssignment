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
        public Deck cardDeck = new Deck(new List<string>() { "Apples", "Oranges", "Bananas", "Pears" }, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
        Person player = new Person();
        Person dealer = new Person();

        public void PrintDeck()
        {
            cardDeck.ShowCards();

        }

       //shuffle made with help from homework example and Janell Baxter
        List<Card> Shuffle(List<Card> unshuffled)
        {
            Random random = new Random();
            return unshuffled.OrderBy(a => random.Next()).ToList();
        }
        public void AppleOranges()
        {
            Title = "Apples or Oranges?!";
            cardDeck.cards = Shuffle(cardDeck.cards);
            string guess = "";
            string target = "";
            int targetIndex = 0;
            string input = "";
            Random randomNumber = new Random();
            targetIndex = randomNumber.Next(0, cardDeck.cards.Count);
            target = cardDeck.cards[targetIndex].Suit;

            Print("The first card drawn is:");
            Print($"{targetIndex} of {target}.");

            Print("Will the next card be the same suit or a different one?");
            Print("Please type the name of the suit: 'Apples', 'Oranges', 'Pears', or 'Bananas'.");
            input = ReadLine();
            
                if (input == target)
                {
                    //match - congratulations!    
                    Print("Congratulations! You guessed " + input + " and I was thinking of " + target + ".");
                    AppleOranges();
                }
                if (input != target)
                {
                    //no match - try again
                    Print("Sorry. You guessed " + input + ". I was thinking of " + target + ". Try again!");
                    AppleOranges();
                }
                else
                {
                    Print("please enter a valid answer.");
                    Pause();
                    AppleOranges();
                }
                ReadKey();

        }


        public void HigherLower()
        {
            Title = "Higher of Lower?!";
            //Made with help from Duncan
            int score =0;
            int NewScore;
            cardDeck.cards = Shuffle(cardDeck.cards);
            int guess = 0;
            int target = 5;
            int targetIndex = 0;
            string input = "";
            Random randomNumber = new Random();
            targetIndex = randomNumber.Next(0,cardDeck.cards.Count);
            target = cardDeck.cards[targetIndex].Value;
            
            Print("The first card drawn is:");
            Print($"{target} of {cardDeck.cards[targetIndex].Suit}.");

            Print("Will the next card be a higher value or lower value?");
            Print("Enter 1 for higher, 2 for lower:");
            input = ReadLine();
            int.TryParse(input, out guess);
            int followIndex = 0;
            followIndex = randomNumber.Next(0, cardDeck.cards.Count);
            int followValue = cardDeck.cards[followIndex].Value;
            if (guess == 1)
            {
                if (followValue > target)
                {
                    Print("Correct");
                    Print($"The new card is {followValue} of {cardDeck.cards[followIndex].Suit}");
                    NewScore = score++;
                    Print($"Score: {score}.");
                    HigherLower();
                }
                else
                {
                    Print("Incorrect");
                    Print($"The new card is {followValue} of {cardDeck.cards[followIndex].Suit}");
                    
                    HigherLower();
                }

            }
            if (guess == 2)
            {
                if (target > followValue)
                {
                    Print("Correct");
                    Print($"The new card is {followValue} of {cardDeck.cards[followIndex].Suit}");
                    NewScore = score++;
                    Print($"Score: {score}.");
                    
                    HigherLower();
                }
                else
                {
                    Print("Incorrect");
                    Print($"The new card is {followValue} of {cardDeck.cards[followIndex].Suit}");
                    
                    HigherLower();
                }

            }
            else
            {
                Print("Please choose a valid number");

            }
            
        }

        

        public void HighestMatch()
        {
            Title = "Highest Match!";
            
            cardDeck.cards = Shuffle(cardDeck.cards);

            for (int i = 0; i < 4; i++)
            {
                DrawRemoveAdd(player);
                DrawRemoveAdd(dealer);
            }
            for (int i = 0; i < 10; i++)
            {
                Clear();
                Print($"Round: {i+ 1} out of 10.");
                Print("Your hand:");
                ShowHand(player);
                Print("Would you like to draw a new card? Type 'yes' or 'no'.");
                if(ReadLine()== "yes")
                {
                    //swap out card
                    Print("Enter the number of the card you would like to swap.");
                    string x = ReadLine();
                    int n = Convert.ToInt32(x);
                    n = n - 1;
                    player.playerHand.RemoveAt(n);
                    DrawRemoveAdd(player);
                }
                if(ReadLine() == "no")
                {
                    //compare to dealer hand
                    CompareToDealer();
                }

            }
            Pause();
        }
       
        private void DrawRemoveAdd(Person person)
        {
            //pull first card at index 0
            Card temp = cardDeck.cards[0];
            //delete card from deck
            cardDeck.cards.Remove(temp);
            //add card to playerHand
            person.playerHand.Add(temp);
        }
        private void ShowHand(Person person)
        {
            for (int i = 0; i < person.playerHand.Count; i++)
            {
                Print($"{i + 1}) {person.playerHand[i].Value} of {person.playerHand[i].Suit}.");
            }
        }
        private void CompareToDealer()
        {
            //print dealer hand
            Print("Dealers hand:");
            ShowHand(dealer);
            //
        }
        private void CompareSuits(Person person)
        {
            int suitApples = 0;
            int suitOranges = 0;
            int suitBananas = 0;
            int suitPears = 0;

            for (int i = 0; i < person.playerHand.Count; i++)
            {
                if (person.playerHand[i].Suit == "Apples")
                {
                    suitApples++;
                }
                else if (person.playerHand[i].Suit == "Oranges")
                {
                    suitOranges++;
                }
                else if (person.playerHand[i].Suit == "Bananas")
                {
                    suitBananas++;
                }
                else if (person.playerHand[i].Suit == "Pears")
                {
                    suitPears++;
                }
            }
            if (suitApples > suitOranges && suitApples > suitBananas && suitApples > suitPears)
            {
                //apples has the most cards
                //add value of Apple cards
                person.playerHand[i].Value++;
            }
            else if (suitOranges > suitApples && suitOranges > suitBananas && suitOranges > suitPears)
            {
                //oranges has the most cards
                //add value of Orange cards
            }
            else if (suitBananas > suitApples && suitBananas > suitOranges && suitBananas > suitPears)
            {
                //bananas has the most cards
                //add value of Banana cards
            }
            else if (suitPears > suitApples && suitPears > suitOranges && suitPears > suitBananas)
            {
                //pears has the most cards
                //add value of Pear cards
            }
        }

        private void AddSuitValues(Person person)
        {

        }
    }
}
