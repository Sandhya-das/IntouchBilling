using System;
using System.Collections.Generic;
using System.Text;

namespace IntouchBilling.Entity
{
    public class Report
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string SearchStatus { get; set; }
        public List<Billing> Billing { get; set; }
    }
}
