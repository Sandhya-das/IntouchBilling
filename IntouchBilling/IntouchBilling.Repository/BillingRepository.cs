using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IntouchBilling.Entity;

namespace IntouchBilling.Repository
{
   public class BillingRepository : IBillingRepository
    {
        private readonly IDapperService _dapperService;

        public BillingRepository(IDapperService dataService)
        {
            _dapperService = dataService;
        }

        public async Task<int> Add(Billing Billing)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", 0, DbType.Int32);
            dbparams.Add("@Category",Billing.Category, DbType.String);
            dbparams.Add("@CusName", Billing.CustomerName, DbType.String);
            dbparams.Add("@Mobile", Billing.Mobile, DbType.String);
            dbparams.Add("@Session", Billing.Session, DbType.String);
            dbparams.Add("@Amount", Billing.Amount, DbType.Decimal);
            dbparams.Add("@PaymentMode",Billing.PaymentMode, DbType.String);
            dbparams.Add("@Status", Billing.Status, DbType.String);
            dbparams.Add("@UserId", Billing.UserId, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[InsertBillingDetails]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<IEnumerable<Billing>> Edit(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("RegId", id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Add<Billing>("[dbo].[UpdateStatus]", dbparams, commandType: CommandType.StoredProcedure));
            List<Billing> BillData = new List<Billing>();
            BillData = await Task.FromResult(_dapperService.GetAll<Billing>("[dbo].[GetAllBillDetails]", dbparams, commandType: CommandType.StoredProcedure));
            List<Billing> name = BillData.ToList();

            return BillData.ToList();
        }

        public async Task<IEnumerable<Billing>> Delete(int Id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("RegId", Id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Add<Billing>("[dbo].[DeleteRegistrationDetails]", dbparams, commandType: CommandType.StoredProcedure));
            List<Billing> BillData = new List<Billing>();
            BillData = await Task.FromResult(_dapperService.GetAll<Billing>("[dbo].[GetAllBillDetails]", dbparams, commandType: CommandType.StoredProcedure));
            List<Billing> name = BillData.ToList();
            
            return BillData.ToList();
        }

        public async Task<IEnumerable<Billing>> GetAllBillDetails()
        {
            var dbparams = new DynamicParameters();
            List<Billing> BillData = new List<Billing>();
            BillData = await Task.FromResult(_dapperService.GetAll<Billing>("[dbo].[GetAllBillDetails]", dbparams, commandType: CommandType.StoredProcedure));
            List<Billing> name = BillData.ToList();
            
            return BillData.ToList();
        }
        public async Task<Billing> GetAllBillById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("RegId", id, DbType.Int32);
            Billing BillData = new Billing();
            BillData = await Task.FromResult(_dapperService.Get<Billing>("[dbo].[GetRegistrationById]", dbparams, commandType: CommandType.StoredProcedure));
            Billing name = BillData;
            return BillData;
        }

    }
}
