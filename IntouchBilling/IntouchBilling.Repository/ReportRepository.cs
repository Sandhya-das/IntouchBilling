using Dapper;
using IntouchBilling.Entity;
using IntouchBilling.Repository.Interface;
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
        //public async Task<IEnumerable<Billing>> Search(Report report)
        //{
        //    Report reports = report;
        //    string billstatus = report.SearchStatus;
        //    var dbparams = new DynamicParameters();
        //    return null;

        //}
    }
}
