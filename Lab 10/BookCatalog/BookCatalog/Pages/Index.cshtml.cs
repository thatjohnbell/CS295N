using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookCatalog.Pages
{
    public class IndexModel : PageModel
    {

        const string NAME = "username";

        private string text;
        private string name;
        public string Text { get { return text; } set { text = value; } }
        [Display(Name = "What Is Your Name?")]
        public string Name { get { return name; } set { name = value; } }





        public IActionResult OnPost()
        {
            string name = HttpContext.Request.Form["name"];
            HttpContext.Session.SetString(NAME, name);

            text = "Thanks, now <a href=\"Books/Index\">click here to view the list</a>.";
            return Page();
        }
    }
}
