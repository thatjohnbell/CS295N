using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1_Number_Guess
{
    public class NumberGuess
    {

        private int num;

        /// <summary>
        /// The correct number.
        /// </summary>
        public int Number
        {
            get { return num; }
            set { num = value; }
        }

        /// <summary>
        /// Constructor that generates a random number, max of 1000 -- use RandomNumber method to generate a new number with a different maximum.
        /// </summary>
        public NumberGuess()
        {
            num = RandomNumber();
        }

        /// <summary>
        /// Construct the object using a given number.
        /// </summary>
        /// <param name="number"></param>
        public NumberGuess(int number)
        {
            num = number;
        }

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <param name="max">The maximum number, default is 1000</param>
        /// <returns>The random number</returns>
        public int RandomNumber(int max = 1000)
        {
            Random rn = new Random();
            return rn.Next(1, max);
        }

        /// <summary>
        /// Check to see if your guess is the correct number.  Returns 0 if correct, -1 if below, or 1 if above.
        /// </summary>
        /// <param name="guess">The guess.</param>
        /// <returns></returns>
        public int CheckAnswer(int guess)
        {
            if (guess > num) return 1;
            else if (guess < num) return -1;
            else return 0;
        }
    }
}
