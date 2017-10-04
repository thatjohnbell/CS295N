using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Instructions.Pages
{
    public class calculatorModel : PageModel
    {
        public string CalculateAge { get; set; }
        public IActionResult OnPost()
        {

            int yearsOld = 0;
            int monthBorn = 0;
            int dayBorn = 0;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            // Retrieve the numbers that the user entered.
            var num1 = Request.Form["text1"];
            var num2 = Request.Form["text2"];
            var num3 = Request.Form["text3"];

            // Calculate age based on year
            yearsOld = year - int.Parse(num1);
            monthBorn = int.Parse(num2);
            dayBorn = int.Parse(num3);
            // Determine whether the persons birthday has already come this year, if not, subtract 1 year

            if (monthBorn > month) 
                yearsOld--;
            else if (monthBorn == month && dayBorn > day)
                yearsOld--;            
            CalculateAge = "You are " + yearsOld + " years old";
            return Page();

            // Something isn't quite right in my calculations. Coming up a year off but I'll get it fixed before it's due
        }
    }
}