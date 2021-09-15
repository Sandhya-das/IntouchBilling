using Dapper;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntouchBilling.Repository
{
   public class ReportRepository : IReportRepository
    {
        private readonly IDapperService _dapperService;

        public ReportRepository(IDapperService dataService)
        {
            _dapperService = dataService;
        }
        public async Task<IEnumerable<Billing>> Search(Report report)
        {          
            string billstatus = report.SearchStatus;
            List<Billing> BillData = new List<Billing>();
            var dbparams = new DynamicParameters();
            if (billstatus =="All")
            {
                dbparams.Add("FromDate", report.FromDate, DbType.Date);
                dbparams.Add("ToDate", report.ToDate, DbType.Date);

                BillData = await Task.FromResult(_dapperService.GetAll<Billing>("[dbo].[SearchRegistrationWithoutStatus]", dbparams, commandType: CommandType.StoredProcedure));
                return BillData.ToList();
            }

            else
            {
                dbparams.Add("FromDate", report.FromDate, DbType.Date);
                dbparams.Add("ToDate", report.ToDate, DbType.Date);
                dbparams.Add("status", billstatus, DbType.String);
                BillData = await Task.FromResult(_dapperService.GetAll<Billing>("[dbo].[SearchRegistration]", dbparams, commandType: CommandType.StoredProcedure));
                return BillData.ToList();
            }

           
        }
    }
}
