using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace IntouchBilling.Pages
{
    [BindProperties]
    public class ReportModel : PageModel
    {
        [BindProperty]

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string SearchStatus { get; set; }

        [BindProperty]
        public List<Billing> Billing { get; set; }

        private IHostingEnvironment _environment;

        private readonly IBillingRepository billingRepository;

        private readonly IReportRepository reportRepository;
        

        [Obsolete]
        public ReportModel(IReportRepository reportRepository,IBillingRepository billingRepository,IHostingEnvironment environment)
        {
            this.billingRepository = billingRepository;
            this.reportRepository = reportRepository;
            _environment = environment;            
        }
        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                return RedirectToPage("Index");
            }

            var billdetails = billingRepository.GetAllBillDetails();
            this.Billing = billdetails.Result.ToList();
            return Page();
        }
        public IActionResult OnPostDelete(int Id)
        {
            var result = billingRepository.Delete(Id);
            return RedirectToPage("Report");
        }
        public IActionResult OnPostUpdate(int Id)
        {
            var result = billingRepository.Edit(Id);
            return RedirectToPage("Report");
        }
        public IActionResult OnPostSearch()
        {
            Report report = new Report
            {
                FromDate = this.FromDate,
                ToDate = this.ToDate,
                SearchStatus = this.SearchStatus,
            };

            var searchResult = reportRepository.Search(report);
            //return new JsonResult(searchResult);

            this.Billing = searchResult.Result.ToList();
            return Page();

        }

    }
}
