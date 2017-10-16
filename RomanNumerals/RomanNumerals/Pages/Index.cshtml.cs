using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RomanNumerals.Pages
{
    public class IndexModel : PageModel
    {

        public string Result = "";

        public IActionResult OnPostIntSub()
        {
            Result = "IntSub";
            return Page();
        }

        public IActionResult OnPostRomSub()
        {
            Result = "RomSub";
            return Page();
        }

    }
}
