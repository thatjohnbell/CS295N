using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RomanNumConv;

namespace RomanNumerals.Pages
{
    public class IndexModel : PageModel
    {

        public string Result { get; set; }
        public string Input { get; set; }


        public IActionResult OnPostIntSub()
        {
            Result = RNConvert.ConvertItoR(int.Parse(Input));
            return Page();
        }

        public IActionResult OnPostRomSub()
        {
            Result = RNConvert.ConvertRtoI(Input).ToString();
            return Page();
        }

    }
}
