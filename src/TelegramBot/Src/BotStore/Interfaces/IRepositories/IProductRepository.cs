using System.Collections.Generic;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Entities;

namespace BotApplication.BotStore.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        public Task<Product> GetProductById(long id);
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductByIndex(int index);
    }
}