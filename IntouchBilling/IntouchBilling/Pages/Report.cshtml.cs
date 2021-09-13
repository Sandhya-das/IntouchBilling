using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using IntouchBilling.Repository.Interface;
using Microsoft.AspNetCore.Hosting;
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
        public List<Billing> Billing { get; set; }

        private IHostingEnvironment _environment;

        private readonly IBillingRepository billingRepository;
        private readonly IReportRepository reportRepository;
        public void OnGet()
        {
            var billdetails = billingRepository.GetAllBillDetails();           
            this.Billing = billdetails.Result.ToList();
        }

        [Obsolete]
        public ReportModel(IBillingRepository billingRepository, IHostingEnvironment environment)
        {
            this.billingRepository = billingRepository;
            _environment = environment;            
        }

        public IActionResult OnPostDelete(int Id)
        {
            var result = billingRepository.Delete(Id);
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
            var id = 0;//reportRepository.Search(report);
            return RedirectToPage("Report");
        }
    }
}
