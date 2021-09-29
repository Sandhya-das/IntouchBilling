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
        public bool Ischecked { get; set; }
        [BindProperty]
        public Billing billing { get; set; }
        private readonly IBillingRepository billingRepository;
        [BindProperty]
        public List<Billing> BillData { get; set; }

        public PrintModel(IBillingRepository billingRepository, IHostingEnvironment environment)
        {
            this.billingRepository = billingRepository;
            _environment = environment;
        }
       
        public IActionResult OnGet(string BillNo)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Login");
            }
            var billdetails = billingRepository.GetAllBillByBillNumber(BillNo);           
            this.BillData = billdetails.Result.ToList();
            List<Billing> bills = billdetails.Result.ToList();           
            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Report");
        }
    }
}
