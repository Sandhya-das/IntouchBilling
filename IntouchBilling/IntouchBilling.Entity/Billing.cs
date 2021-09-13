using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IntouchBilling.Entity
{
    public class Billing
    {
        [Key]
        public int Id { get; set; }

        public string Category { get; set; }

        public string CustomerName { get; set; }

        public string Mobile { get; set; }

        public string Session { get; set;}

        public float Amount { get; set; }

        public string PaymentMode { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
