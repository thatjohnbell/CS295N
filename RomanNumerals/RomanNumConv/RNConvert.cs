using System;

namespace RomanNumConv
{
    public class RNConvert
    {
        string[] ro = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };


        /// <summary>
        /// Conver a Roman Numeral to an Integer.
        /// </summary>
        /// <param name="r">Roman Decimal String</param>
        /// <returns>Arabaic Integer</returns>
        public int ConvertRtoI(string r)
        {
            return Array.IndexOf(ro,r)+1;
        }

        /// <summary>
        /// Convert Arabic Integer to Roman Numeral
        /// </summary>
        /// <param name="i">Arabic Intiger</param>
        /// <returns>Roman Decimal String</returns>
        public string ConvertItoR(int i)
        {

            return ro[i-1];
        }


        //Convert a integer to a roman numeral



    }
}
