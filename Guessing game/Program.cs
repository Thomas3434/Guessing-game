using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_game
{
    internal sealed class Program
    {
        private int numberOfGuesses; //amount of guesses that the user has done
        private int numberToGuess; //the number that the user has to guess

        static void Main(string[] args)
        {
            bool firstGame = true; // this parameter is used to determine if the 'want to play again?' option from GuessingGame should be shown.
            var p = new Program();
            p.GuessingGame(firstGame);
        }

        private void GuessingGame(bool firstGame)
        /* Immediately calls StartGame if firstGame is set to true.
         * If not then it will asks the user if they want to play again, run the game again if they do or exits if they dont.
         */
        {
            if (firstGame == true)
            {
                StartGame();
            }

            else
            {
                Console.WriteLine("Want to play again?");
                Console.WriteLine("1) Yes");
                Console.WriteLine("2) No");
                Console.Write("My choice: ");
                string myChoice = Console.ReadLine();

                if (myChoice == "1")
                {
                    StartGame();
                }

                else if (myChoice == "2")
                {
                    Environment.Exit(0);
                }

                else //This filters our invalid inputs.
                {
                    Console.WriteLine("Choose either 1 or 2.");
                    GuessingGame(firstGame);
                }
            }
        }

        private void StartGame()
        {
            //Clears the screen, resets the amount of guesses, shows startup message and start 'GenerateNumberToGuess' method
            Console.Clear();
            numberOfGuesses = 1;
            Console.WriteLine("Guess a number from 1 to 100!");
            GenerateNumberToGuess();
        }

        private void GenerateNumberToGuess()
        {
            //Generates a number between 1 and 100 and passes this on to 'GuessingAttempt' method
            Random randomnumber = new Random();
            numberToGuess = randomnumber.Next(0, 100) + 1;
            GuessingAttempt();
        }

        private void GuessingAttempt()
        {
            /* 
             * Requests a guess from the user and validates the input.
             * Non-Integers or integers outside the 1-100 range prompt an error message and restart this method
             * Valid input gets passed to 'Compare' method
             */
            Console.Write("My guess: ");
            string myGuess = Console.ReadLine();

            int inputNumber;
            if (!int.TryParse(myGuess, out inputNumber) || (inputNumber > 100 || inputNumber < 1))
            {
                Console.WriteLine("That is not a valid input. Please choose a number between 1 and 100.");
                GuessingAttempt();
            }

            else
                Compare(inputNumber);
        }

        private void Compare(int inputNumber)
        {
            /*
             * Compares the input from 'GuessingAttempt' method with the number generated in 'GenerateNumberToGuess'method.
             * Provides feedback wether the target number is higher, lower or matching the input.
             * Adds 1 to the amount of guesses done
             */
            while (inputNumber != numberToGuess)
            {
                if (inputNumber > numberToGuess)
                {
                    Console.WriteLine("Lower!");
                }

                else
                {
                    Console.WriteLine("Higher!");
                }

                numberOfGuesses++;
                GuessingAttempt();
            }
            Console.WriteLine("Correct! You won in {0} attempts!", numberOfGuesses);
            Console.WriteLine("=================================");
            bool firstGame = false; //This lets GuessingGame know that it is not the user's first game
            GuessingGame(firstGame); //Prompts the menu to restart or exit the game 

            Console.ReadLine();
        }
    }
}