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
        public int Answer { get; set; }
        public string Message { get; set; }


        public void OnGet()
        {
            Answer = RandomNumber();
            Message = "Enter your guess below:";
        }





 

        public IActionResult OnPost()
        {
            Answer = int.Parse(Request.Form["answer"]);

            try
            {
                int guess = int.Parse(Request.Form["guess"]);
                if (guess > Answer) Message = "Too High!<br />&nbsp;<br />Guess again:";
                else if (guess < Answer) Message = "Too Low!<br />&nbsp;<br />You'll get it this time!";
                else
                {
                    Message = "Wow! You got it!<br /><font size=\"+1\">The Number Was " + Answer + "!</font><br />&nbsp;<br />I've got a harder one now..<br />Try and see if you can guess it!";
                    Answer = RandomNumber();
                }


            }
            catch
            {
                Message = "Oops, we couldn't check that number, try again!";
            }


            
            return Page();

        }


        public int RandomNumber()
        {
                Random rn = new Random();
            return rn.Next(1, 1000);
        }



    }
}