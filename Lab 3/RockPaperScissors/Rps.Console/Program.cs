/* Written by Brian Bird    *
 * 10/10/17                 */

using System;
using Rps.Library;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // introduce and initialize the game
            Console.WriteLine("Welcome to the game of Rock, Paper, Scissors!");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            var game = new RpsLogic();
            game.PlayerName = name;

            // Game-play loop
            string playAgain = "yes";
            do
            {
                // Get the human player's choice
                string machineChoice = game.ChooseHand().ToString();  // the machine makes it's move
                Console.Write("Please enter rock, paper, or scissors: ");
                string choice = Console.ReadLine();

                // Get the machine's choice and display the winner
                Console.WriteLine("The machine chose: " + machineChoice);
                string winner = game.WhoWon(choice);
                Console.WriteLine(winner);

                // Do it again?
                Console.WriteLine("---------------");
                Console.Write("Do you want to play again? (yes or no) :");
                playAgain = Console.ReadLine().ToLower();
                Console.WriteLine("---------------");

           } while (playAgain == "yes" || playAgain == "y");

        }
    }
}
