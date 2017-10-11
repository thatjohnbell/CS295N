using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace Lab_1_Number_Guess.Pages
{
    public class PlayModel : PageModel
    {
        private int answer;

        /// <summary>
        /// Message property, stores the instructions / results, assigned in OnGet and OnPost methods
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Answer property, used with NumberGuess object number property.
        /// </summary>
        public int Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        NumberGuess ng;
        const string RND_NUM = "Random_Number";

        /// <summary>
        /// On Get event trigger
        /// </summary>
        public void OnGet()
        {
            answer = NewNumber();
            Message = "Enter your guess below:";
        }
        
        /// <summary>
        /// On Post event trigger
        /// </summary>
        /// <returns>Returns the page with result paramaters.</returns>
        public IActionResult OnPost()
        {
            answer = GetNumber();
            try
            {
                NumberGuess ng = new NumberGuess(answer);
                int guess = int.Parse(Request.Form["guess"]);
                //if the checkanswer method finds a match then it will select a new random number, will return display text string
                //best practice would have been to return a value then assign the string based on value since the text of the message should be on presentation layer and not business
                int check = ng.CheckAnswer(guess);
                if (check > 0) Message = "Too High!<br />&nbsp;<br />Guess again:";
                else if (check < 0) Message = "Too Low!<br />&nbsp;<br />You'll get it this time!";
                else
                {
                    Message = "Wow! You got it!<br /><font size=\"+1\">The Number Was " + answer + "!</font><br />&nbsp;<br />I've got a harder one now..<br />Try and see if you can guess it!";
                    answer = NewNumber();
                }
            }
            catch
            {
                //if something above failed then have them try again
                Message = "Oops, we couldn't check that number, try again!";
            }
            return Page();
        }

        /// <summary>
        /// Save the number to the session // called in New Number method.
        /// </summary>
        /// <param name="number">The number to save</param>
        public void SaveNumber(int number)
        {
            HttpContext.Session.SetInt32(RND_NUM,number);
        }

        /// <summary>
        /// Generate a new number and save it to session data
        /// </summary>
        /// <returns>The number</returns>
        public int NewNumber()
        {
            ng = new NumberGuess();
            answer = ng.Number;
            SaveNumber(answer);
            return answer;
        }

        /// <summary>
        /// Get the number from the session data, generates a new number if none are found.
        /// </summary>
        /// <returns>the number</returns>
        public int GetNumber()
        {
            int r = (int)HttpContext.Session.GetInt32(RND_NUM);
            if (r == 0) answer = NewNumber();
            return r;
        }
    }


}