using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ICTPRG302_Intro_to_Programming
{
    class Gamertags
    {
        // The list of gamer tags loaded from file
        private List<string> gamerTagList = new List<string>();

        public void LoadGamertags()
        {
            string[] tempArray = File.ReadAllLines("../Gamertags.txt");
            foreach (string item in tempArray)
            {
                gamerTagList.Add(item);
            }
        }

        public void OfferChoice()
        {
            int userChoice;

            Console.WriteLine("-------------------------");
            Console.WriteLine("Press the number key indicated at the front of your desired dataset");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            Console.WriteLine("[1]: All gamertags");
            Console.WriteLine("[2]: Gamertags ending in numbers");
            Console.WriteLine("[3]: Gamertags not starting in a letter or a number");
            Console.WriteLine("[4]: First 5 gamertags");
            Console.WriteLine("[5]: Add a new gamertag to the list");
            Console.WriteLine("[6]: Exit program");
            Console.WriteLine("");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 1)
                {
                    PrintAllGamertags();
                }
                else if (userChoice == 2)
                {
                    PrintGamertagsEndingInNumber();
                }
                else if (userChoice == 3)
                {
                    PrintGamertagsNotStartingInLetterOrNumber();
                }
                else if (userChoice == 4)
                {
                    PrintFirst5Gamertags();
                }
                else if (userChoice == 5)
                {
                    MakeNewGamertag();
                }
                else if (userChoice == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                OfferChoice();
            }
        }

        public void WelcomeMessage()
        {
            // Display welcome message
            Console.WriteLine("-------------------------");
            Console.WriteLine("Welcome to the gamertag database");
            Console.WriteLine("-------------------------");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            OfferChoice();
        }

        public void PrintAllGamertags()
        {
            // Print Header
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("All Gamertags");
            Console.WriteLine("-------------------------");

            // Loop over list of gamertags and print them all one by one
            int lineNumber = 1;
            foreach (string s in gamerTagList)
            {
                Console.WriteLine(lineNumber.ToString() + ") " + s);
                lineNumber++;
            }

            // Display message to user
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            OfferChoice();
        }
        
        public void PrintGamertagsEndingInNumber()
        {
            // Write a header
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Gamertags ending in a number");
            Console.WriteLine("-------------------------");

            // Loop over the list of gamertags and print them all in new lines
            int lineNumber = 1;
            foreach (string s in gamerTagList)
            {
                // Test each gamertagto ensure it has at least one character,
                // AND the last character in it is a number
                // If both tests pass, then it prints the gamertag
                if ((s.Length > 0) && Char.IsNumber(s, s.Length - 1))
                {
                    // Format a line for ecah gamertag with a number in front
                    // Note: There are alternative memory-efficient methods to concatenate strings
                    Console.WriteLine(lineNumber.ToString() + ")" + s);
                    lineNumber++;
                }
            }

            // Display message to user
            Console.WriteLine("Press any key to continue");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
            OfferChoice();
        }

        public void PrintGamertagsNotStartingInLetterOrNumber()
        {
            // Write a header
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Gamertags not starting in a letter or number");
            Console.WriteLine("-------------------------");

            // Loop over the list of gamertags and print them all in new lines
            int lineNumber = 1;
            foreach (string s in gamerTagList)
            {
                // Test each gamertag to ensure it does not start in a letter or a number
                // If the test passes it prints the gamertag
                if (!Char.IsLetterOrDigit(s, 0))
                {
                    // Format a new line for each gamertag with a new number in front
                    Console.WriteLine(lineNumber.ToString() + ")" + s);
                    lineNumber++;
                }
            }

            // Display message to user
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            OfferChoice();
        }

        public void PrintFirst5Gamertags()
        {
            // Print header
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("First 5 Gamertags");
            Console.WriteLine("-------------------------");

            // Loop over list of gamertags and print the first 5 of them
            int lineNumber = 1;
            foreach (string s in gamerTagList)
            {
                Console.WriteLine(lineNumber.ToString() + ")" + s);
                lineNumber++;
                if (lineNumber == 6)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            OfferChoice();
        }

        public void MakeNewGamertag()
        {
            Console.Clear();

        
            Console.WriteLine("-------------------------");
            Console.WriteLine("Make a new gamertag");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Please input new gamertag:");

            gamerTagList.Add(Console.ReadLine());

            File.WriteAllLines("Gamertags.txt", gamerTagList);

            Console.WriteLine();
            Console.WriteLine("Gamertag added");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            OfferChoice();
        }
    }
}
