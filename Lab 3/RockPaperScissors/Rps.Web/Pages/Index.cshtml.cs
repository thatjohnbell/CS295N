using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rps.Library;
using Microsoft.AspNetCore.Http;


namespace Rps.Web.Pages
{
    public class IndexModel : PageModel
    {
        private int winner;
        private string scores;
        private string mess = "Will You win this game of Rock Paper Scissors?";
        private string name;
        private string jqExtras;

        const string PLAYERNAME = "Player_Score";
        const string CPUNAME = "Cpu_Score";
        const string NAME = "Player_Name";

        #region properties

        public string Message
        {
            get { return mess; }
            set { value = mess; }
        }

        public string Score
        {
            get { return scores; }
            set { scores = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string JQueryExtras { get { return jqExtras; } }

        #endregion


        #region request events
        public void OnGet()
        {
            scores = "";
            name = "";
            jqExtras = "$(\"#nameDisplay\").hide(); $(\"#gameForm\").hide();";
            SetScore(PLAYERNAME, 0);
                SetScore(CPUNAME, 0);
        }

        public IActionResult OnPost()
        {
            //hide initial name prompt div since we have a name to display
            jqExtras = "$(\"#nameForm\").hide();";

            //get name from session and save if updated since last
            name = GetPlayerName();
            if (name != Request.Form["name"])
            {
                name = Request.Form["name"];
                SavePlayerName(name);
            }

            name = Request.Form["name"];

            //get session data for scores and user
            int pscore = GetScores(PLAYERNAME);
            int cscore = GetScores(CPUNAME);

            //create rps object and get info
            RpsLogic rps = new RpsLogic();
            rps.ChooseHand();
            winner = rps.WhoWon(Request.Form["playerGuess"]);

            mess = "You Chose " + Request.Form["playerGuess"] +"<br /><img src=\"images/" + Request.Form["playerGuess"] + ".png\"><br />The Computer Chose "+rps.CpuHand+"<br /><img src=\"images/" +rps.CpuHand + ".png\"><p />";

            //I updated your RPSLogic class to output an int instead of a string for versatility
            //check if winner and make updates
            if (winner < 0)
            {
                mess += "Oh no, the Computer Won<p />";
                SetScore(CPUNAME, ++cscore);
            }
            else if (winner > 0)
            {
                mess += "Yay, You Won!<p />";
                SetScore(PLAYERNAME, ++pscore);
            }
            else
            {
                mess += "Tie Game! Try again!<p />";
            }

            //update score display, saying 'your score' instead of name because it is more personal, name is already displayed in welcome message on top as well
            scores = "Your Wins: " + pscore + "<br />Computer Wins: " + cscore;
            return Page();
        }

        #endregion


        #region client session methods

        public void SavePlayerName(string name)
        {
            HttpContext.Session.SetString(NAME, name);
        }

        public string GetPlayerName()
        {
            return HttpContext.Session.GetString(NAME);
        }

        public int GetScores(string name)
        {
            if (HttpContext.Session.GetInt32(name) == null) return 0;
                else return (int)HttpContext.Session.GetInt32(name);
        }

        public void SetScore(string name, int score)
        {
            try
            {
                HttpContext.Session.SetInt32(name, score);
            }
            catch (Exception ex)
            {
                name = ex.ToString();
            } 
        }
        #endregion
    }
}