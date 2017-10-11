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
        private string mess;
        private string name;
        private string cont;

        const string PLAYERNAME = "Player_Score";
        const string CPUNAME = "Cpu_Score";
        const string NAME = "Player_Name";

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

        public string Content { get { return cont; } }


        public void OnGet()
        {
            mess = "";
            scores = "";
            name = "";
            cont = "Enter Your Name to Begin:<br /><form method=\"post\"><input type=\"text\" name=\"@PLAYERNAME\"><br /><input type=\"Submit\" value=\"Go\">";
        }

        public void OnPost()
        {
            //if the user submitted the name form, then submit it and display guess form, user form is displayed on get
            if (Request.QueryString.ToString().IndexOf(PLAYERNAME) !=0)
            {
                SavePlayerName(Request.Form[PLAYERNAME]);

            }
            //otherwise process their guess and display info, display rps form outside of this sequence
            else
            {
                //fill name from session
                name = GetPlayerName();

                //get session data for scores and user
                int pscore = GetScores(PLAYERNAME);
                int cscore = GetScores(CPUNAME);

                //see what they selected
                string user = Request.Form["user"];
 
                //create rps object and get info
                RpsLogic rps = new RpsLogic();
                rps.ChooseHand();
                winner = rps.WhoWon(user);

                //I updated your RPSLogic class to output an int instead of a string for versatility
                //check if winner and make updates
                if (winner < 0)
                {
                    mess = "Oh no, the Computer Won<p />";
                    SetScore(CPUNAME, cscore++);
                }
                else if (winner > 0)
                {
                    mess = "Yay, You Won!<p />";
                    SetScore(PLAYERNAME, pscore++);
                }
                else
                {
                    mess = "Tie Game! Try again!<p />";
                }
            }


            //in this content add the form and then the score output and then spend sixteen hours fixing the bugs you just made :p
            cont = mess + "";

        }

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
            return (int)HttpContext.Session.GetInt32(name);
        }

        public void SetScore(string name, int score)
        {
            HttpContext.Session.SetInt32(name, score);
        }

    }
}