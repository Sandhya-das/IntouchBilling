using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Pages
{
    [BindProperties]
    public class PrintModel : PageModel
    {
       
        private IHostingEnvironment _environment;

        public string BillNumber { get; set; }

        [BindProperty]
        public Billing billing { get; set; }

        private readonly IBillingRepository billingRepository;
        public List<Billing> BillData { get; set; }
        public PrintModel(IBillingRepository billingRepository, IHostingEnvironment environment)
        {
            this.billingRepository = billingRepository;
            _environment = environment;
        }
        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Login");
            }
            
            int RegId = id;
            var bill = billingRepository.GetAllBillById(RegId);
            this.billing = bill.Result;
            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Report");
        }
    }
}
