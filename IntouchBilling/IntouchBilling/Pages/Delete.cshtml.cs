using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Pages
{
    public class DeleteModel : PageModel
    {


        private readonly IBillingRepository billingRepository;


        public IActionResult OnGet(int Id)
        {
            var result = billingRepository.Delete(Id);
            return RedirectToPage("Report");
        }
    }
}
