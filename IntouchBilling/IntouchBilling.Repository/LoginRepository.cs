using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IntouchBilling.Entity;
using IntouchBilling.Repository;
using Microsoft.Extensions.Configuration;

namespace IntouchBilling.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDapperService _dapperService;
        public LoginRepository(IDapperService dataService)
        {
            _dapperService = dataService;
            // this.mapper = mapper;
        }
        public async Task<Login> GetData(Login login)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("UserName", login.Username, DbType.String);
            dbparams.Add("Password", login.Password, DbType.String);
            var result = await Task.FromResult(_dapperService.Get<Entity.Login>("[dbo].[LoginByUsernamePassword]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
       
    }
}
