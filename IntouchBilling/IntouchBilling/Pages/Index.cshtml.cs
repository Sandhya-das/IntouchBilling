using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private string Name { get; set; }
        public IActionResult OnGet()
        {
            //Redirect("/Login");
            return RedirectToPage("Login");
        }
    }
}
