using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using static CardGameAssignment.Utility;

namespace CardGameAssignment
{
    class Application
    {
        Game appleOrange = new Game();
        List<Card> cards = new List<Card>();

        Person Player = new Person();
        public List<Game> games = new List<Game>();

        List<string> suits = new List<string>()
        {
            "Apples","Oranges"
        };

        List<int> values = new List<int>()
        {
            2,3,4,5,6,7,8,9,10,11,12,13,14
        };
        public void LoadGame()
        {
            //Player.playerName = "Anonymous Player";
            Title = "Card Games!";

            ShowMenu();
            Pause();
            //Deck deck = new Deck(suits, values);
            //deck.ShowCards();
        }

        public void ShowMenu()
        {
            string[] options = new string[] { "Apples VS Oranges", "Higher or Lower", "Highest Match", "Show Credits", "Exit" };

            int choice = GetPlayerChoice("What would you like to play?", options);

            Console.Clear();

            switch (choice)
            {
                case 0:
                    appleOrange.AppleOranges();
                    break;
                case 1:
                    //higher or lower
                    break;
                case 2:
                    //highes match
                    break;
                case 3:
                    ShowCredits();
                    Clear();
                    ShowMenu();
                    break;
                case 4:
                    //Exit
                    WriteLine("Thank you for playing");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    //if a number other than 1-4 is entered, ask the player to enter a number in that range
                    //wait for them to press enter, then call the menu again
                    WriteLine("Please enter a number 1-5.");
                    WriteLine("Press enter to continue...");
                    ReadLine();
                    ShowMenu();
                    break;
            }

        }

        public Card DrawCard()
        {
            return cards[0]; 
        }

        //PROG 201 Demo Code
       
        public void ShowCredits()
        {
            Print("This game was made by Hannah Stern for Programming 201");
            Print("With help from the tutors and Janell Baxter");
            Pause();
        }
    }
}
