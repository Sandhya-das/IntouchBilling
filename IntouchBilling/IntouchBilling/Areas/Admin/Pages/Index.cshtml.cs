using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Areas.Admin.Pages
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
