using System;

namespace RomanNumConv
{
    public class RNConvert
    {


        /// <summary>
        /// Conver a Roman Numeral to an Integer.
        /// </summary>
        /// <param name="r">Roman Decimal String</param>
        /// <returns>Arabaic Integer</returns>
        public static int ConvertRtoI(string r)
        {
            string[] ro = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

            return Array.IndexOf(ro,r)+1;
        }

        /// <summary>
        /// Convert Arabic Integer to Roman Numeral
        /// </summary>
        /// <param name="i">Arabic Intiger</param>
        /// <returns>Roman Decimal String</returns>
        public static string ConvertItoR(int i)
        {
            string[] ro = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };


            return ro[i-1];
        }

    }
}
