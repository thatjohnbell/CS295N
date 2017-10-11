using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1_Number_Guess
{
    public class NumberGuess
    {

        private int num;

        public int Number
        {
            get { return num; }
            set { num = value; }
        }

        public NumberGuess()
        {
            num = RandomNumber();
        }

        public NumberGuess(int number)
        {
            num = number;
        }

        public int RandomNumber()
        {
            Random rn = new Random();
            return rn.Next(1, 1000);
        }

        public int CheckAnswer(int guess)
        {
            if (guess > num) return 1;
            else if (guess < num) return -1;
            else return 0;
        }
    }
}
