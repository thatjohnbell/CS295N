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

        public string Message { get; set; }

        public int Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        NumberGuess ng;
        const string RND_NUM = "Random_Number";

        //on get request
        public void OnGet()
        {
            answer = NewNumber();
            Message = "Enter your guess below:";
        }
        
        //on post request
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
        //assign number to session
        public void SaveNumber(int number)
        {
            HttpContext.Session.SetInt32(RND_NUM,number);
        }

        public int NewNumber()
        {
            ng = new NumberGuess();
            answer = ng.Number;
            SaveNumber(answer);
            return answer;
        }

        public int GetNumber()
        {
            int r = (int)HttpContext.Session.GetInt32(RND_NUM);
            if (r == 0) answer = NewNumber();
            return r;
        }
    }


}