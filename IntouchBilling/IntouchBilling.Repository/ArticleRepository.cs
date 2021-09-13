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
    public class ArticleRepository : IArticleRepository
    {
        private readonly IDapperService _dapperService;
        // private readonly IMapper mapper;
        //IConfiguration _configuration;

        //public ArticleRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public ArticleRepository(IDapperService dataService)
        {
            _dapperService = dataService;
            // this.mapper = mapper;
        }
        public async Task<IEnumerable<Article>>FileUpload(Article file)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Article>("[dbo].[SP_SELECT_Article]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }



        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            var dbparams = new DynamicParameters();
            List<Article> ArticleData = new List<Article>();
            //            dbparams.Add("InputType", "SELECT", DbType.String);
           ArticleData = await Task.FromResult(_dapperService.GetAll<Article>("[dbo].[proSelectArticleDetails]", dbparams, commandType: CommandType.StoredProcedure));
            return ArticleData.ToList();
           
        }

        public async Task<Article> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            dbparams.Add("ArticleId",id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Get<Article>("[dbo].[SP_SELECT_Article]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<Article> GetData()
        {
            var dbparams = new DynamicParameters();
            //dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            //dbparams.Add("ArticleId", id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Get<Article>("[dbo].[proSelectArticleDetails]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
        //public async Task<int> Add(Article Article)
        //{

        //    var dbparams = new DynamicParameters();

        //    var connectionString = this.GetConnection();
        //    int count = 0;
        //    using (var con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            dbparams.Add("Title", Article.Title, DbType.String);
        //            dbparams.Add("Content", Article.Content, DbType.String);

        //            con.Execute("SP_IUD_Article", dbparams, commandType: CommandType.StoredProcedure);

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }

        //        return count;

        //    }


        //}

        public async Task<int> Add(Article Article)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ArticleId", 0, DbType.Int32);
            dbparams.Add("Title", Article.Title, DbType.String);
            dbparams.Add("Content", Article.Content, DbType.String);
            dbparams.Add("ImageName", Article.ImageName, DbType.String);
            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_Article]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }

        public async Task<int> Edit(Article Article)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ArticleId", Article.Id, DbType.Int32);
            dbparams.Add("Title", Article.Title, DbType.String);
            dbparams.Add("Content", Article.Content, DbType.String);
            dbparams.Add("ImageName", Article.ImageName, DbType.String);
            var result = await Task.FromResult(_dapperService.Edit<int>("[dbo].[SP_IUD_Article]", dbparams,commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ArticleId",id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Execute("[dbo].[SP_IUD_Article]",dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        //public string GetConnection()
        //{
        //    var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        //    return connection;
        //}
    }
}
                                                                                                                                                                                                                                                                                    