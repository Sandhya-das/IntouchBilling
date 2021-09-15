using IntouchBilling.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntouchBilling.Repository
{
    public interface IReportRepository
    {
       Task<IEnumerable<Billing>> Search(Report report);
    }
}
