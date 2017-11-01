using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Pages
{
    public class IndexModel : PageModel
    {
        private string text;
        private string name;
        public string Text { get { return text; } set { text = value; } }
        [Display(Name = "Your Name")]
        public string Name { get { return name; } set { name = value; } }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            text = "Thanks, now <a href=\"Books/Index\">click here to view the list</a>.";
            return Page();
        }
    }
}
