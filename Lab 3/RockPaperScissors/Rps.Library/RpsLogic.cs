/* Written by Brian Bird    *
 * 4/27/16                  *
 * Revised 10/10/17         */

using System;

namespace Rps.Library
{

    public enum handShape { rock, paper, scissors }

    public class RpsLogic
    {
        Random rand = new Random();
        handShape machineHand;


        /// <summary>
        /// Randomly chooses a number to represent a hand position.
        /// </summary>
        /// <returns>1 for rock, 2 for paper, 3 for scissors.</returns>
        public handShape ChooseHand()
        {
            machineHand = (handShape)rand.Next(3);
            return machineHand;  // produces random 0 through 2
        }


        //altered your class because I don't want to have to translate messages into the UI
        //makes more sense (to me) to return a value I can translate on the presentation layer
        /// <summary>
        /// checks to see who won
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>-1 for lose, 0 for tie, 1 for win</returns>
        public int WhoWon(string hand)
        {
            // Convert the user's hand shape choice to an enum
            handShape playerHand = (handShape)Enum.Parse(typeof(handShape), hand.ToLower());
            if (playerHand == machineHand)
                return 0;
            else if ((playerHand == handShape.rock && machineHand == handShape.scissors) ||
                     (playerHand > machineHand && !(machineHand == handShape.rock && playerHand == handShape.scissors)))
                return 1;
            else
                return -1;
        }
    }
}

