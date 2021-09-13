using IntouchBilling.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntouchBilling.Repository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
        //List<Article> GetAllArticles();
        Task<Article> GetById(int id);
        Task<Article> GetData();
        Task<int> Add(Article Article);
        Task<int> Edit(Article Article);
        Task<int> Delete(int id);
        

    }
}
