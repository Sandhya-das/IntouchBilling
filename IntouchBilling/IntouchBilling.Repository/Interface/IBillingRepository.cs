using IntouchBilling.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntouchBilling.Repository
{
   public interface IBillingRepository
    {
        Task<IEnumerable<Billing>> GetAllBillDetails();
        Task<int> Add(Billing Billing);
        Task<IEnumerable<Billing>> Edit(int id);
        Task<IEnumerable<Billing>> Delete(int id);

    }
}
