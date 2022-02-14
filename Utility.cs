using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameAssignment
{
    //Utility code based on code from class and code created for a Programming 101 assignment
    class Utility
    {
        public static void Pause()
        {
            //press a key to continue
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Print(string message)
        {
            //prints to screen
            Console.WriteLine(message);
        }

        public string ConvertToLowerCase(string message) => message.ToLower();


        public static int GetPlayerChoice(string title, List<string> items)
        {
            return GetPlayerChoice(title, items.ToArray());
        }

        //show user a list of options and have them choose a valid response
        public static int GetPlayerChoice(string title, string[] items)
        {
            Console.WriteLine(title);
            for (int i = 0; i < items.Length; i++)
            {
                int roomNumber = i + 1;
                string details = $"{roomNumber}) {items[i]}";
                Console.WriteLine(details);
            }
            return GetAValidNumberFromPlayer(items.Length);
        }


        public static int GetAValidNumberFromPlayer(int numberOfItems)
        {
            Console.WriteLine($"Please pick a number between 1 and {numberOfItems}");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number > 0 && number <= numberOfItems)
                {
                    number--;
                   
                    return number;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You didn't enter a valid number");
                
            }
            //Recursive function
            return GetAValidNumberFromPlayer(numberOfItems);
        }

        
    }

}
