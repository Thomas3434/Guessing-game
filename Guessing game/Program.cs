using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_game
{
    class Program
    {
        static int guesses; //amount of guesses that the user has done
        static int target; //the number that the user has to guess

        static void Main(string[] args)
        {
            //Clears the screen, resets the amount of guesses, shows startup message and start 'GenerateTarget' method
            Console.Clear();
            guesses = 0;
            Console.WriteLine("Guess a number from 1 to 100!");
            GenerateTarget();
        }

        static void GenerateTarget()
        {
            //Generates a number between 1 and 100 and passes this on to 'Guess' method
            Random randomnumber = new Random();
            target = randomnumber.Next(0, 100);
            target++;
            Guess(target);
        }

        static void Guess(int target)
        {
            /* 
             * Requests a guess from the user and validates if the input is an integer.
             * Integers get passed to 'Compare' method
             * Non-Integers prompt an error message and restart this method
             */
            Console.Write("My guess: ");
            string myGuess = Console.ReadLine();

            int inputNumber;
            if (!int.TryParse(myGuess, out inputNumber))
            {
                Console.WriteLine("That is not a valid input.");
                Guess(target);
            }
            else
                Compare(inputNumber, target);
        }

        static void Compare(int inputNumber, int target)
        {
            /*
             * Compares the input from 'Guess' method with the number generated in 'GenerateTarget'method.
             * Provides feedback wether the target number is higher, lower or matching the input.
             * Adds 1 to the amount of guesses done
             */
            if (inputNumber == target)
            {
                Console.WriteLine("Correct! You won in {0} attempts!", guesses);
                Console.WriteLine("=================================");
                Retry();
            }

            else if (inputNumber > target)
                Console.WriteLine("Lower!");

            if (inputNumber < target)
                Console.WriteLine("Higher!");

            guesses++;
            Guess(target);

            Console.ReadLine();
        }

        static bool Retry()
        {
            /*
             * Asks user to either continue and restart the game or exit the game.
             */
            Console.WriteLine("Want to play again?");
            Console.WriteLine("1) Yes");
            Console.WriteLine("2) No");
            Console.Write("My choice:");
            string myChoice = Console.ReadLine();

            if (myChoice == "1")
            {
                //Would be more elegant if I could use the code in the Main method instead.
                Console.Clear();
                guesses = 0;
                Console.WriteLine("Guess a number from 1 to 100!");
                GenerateTarget();
                return true;
            }

            else if (myChoice == "2")
            {
                return false;
            }

            else //This filters our invalid inputs.
            {
                Console.WriteLine("Choose either 1 or 2.");
                Retry();
                return true;
            }

        }

    }
}
