/* Written by Brian Bird    *
 * 4/27/16                  *
 * Revised 10/10/17         */

using System;

namespace Rps.Library
{

    public enum HandShape { rock, paper, scissors }

    public class RpsLogic
    {
        Random rand = new Random();
        HandShape machineHand;


        /// <summary>
        /// Randomly chooses a number to represent a hand position.
        /// </summary>
        /// <returns>0 for rock, 1 for paper, 2 for scissors.</returns>

            public string CpuHand { get { return machineHand.ToString(); } }

        public HandShape ChooseHand()
        {
            machineHand = (HandShape)rand.Next(3);
            return machineHand;
        }


        //altered your class because I don't want to have to translate messages into the UI
        //makes more sense (to me) to return a value I can translate on the presentation layer
        /// <summary>
        /// checks to see who won
        /// </summary>
        /// <param name="hand">player guess</param>
        /// <returns>-1 for lose, 0 for tie, 1 for win</returns>
        public int WhoWon(string hand)
        {
            if (hand == null) throw new ArgumentNullException("Hand cannot be null, must be 'rock', 'paper', or 'scissors'");

            // Convert the user's hand shape choice to an enum
            HandShape playerHand = (HandShape)Enum.Parse(typeof(HandShape), hand.ToLower());
            if (playerHand == machineHand)
                return 0;
            else if ((playerHand == HandShape.rock && machineHand == HandShape.scissors) ||
                     (playerHand > machineHand && !(machineHand == HandShape.rock && playerHand == HandShape.scissors)))
                return 1;
            else
                return -1;
        }
    }
}

