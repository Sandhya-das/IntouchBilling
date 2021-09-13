using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntouchBilling.Pages
{
    [BindProperties]
    public class BillingModel : PageModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Session { get; set; }

        [Required]
        public float Amount { get; set; }
        [Required]
        [Display(Name = "Mode of Payment")]
        public string PaymentMode { get; set; }
        [Required]
        public string Status { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Date")]
        public DateTime CreatedOn { get; set; }

        private IHostingEnvironment _environment;

        private readonly IBillingRepository billingRepository;
        public List<Billing> BillData { get; set; }
        public BillingModel(IBillingRepository billingRepository, IHostingEnvironment environment)
        {
            this.billingRepository = billingRepository;
            _environment = environment;
        }
        public void OnGet( int id)
        {
            int Id = id;
                    
        }

        public IActionResult OnPost()
        {
     
            Billing billing = new Billing
            {
                Category = this.Category,
                CustomerName = this.CustomerName,
                Mobile = this.Mobile,
                Session = this.Session,
                Amount = this.Amount,
                PaymentMode = this.PaymentMode,
                Status = this.Status,
                UserId = Id
            };
           
            var id = billingRepository.Add(billing);
            return RedirectToPage("Report");
        }
           
    }
}
