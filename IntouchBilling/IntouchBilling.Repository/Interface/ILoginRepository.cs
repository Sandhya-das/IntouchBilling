using IntouchBilling.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntouchBilling.Repository
{
    public interface ILoginRepository
    {
        Task<Login> GetData(Login login);
    }
}
