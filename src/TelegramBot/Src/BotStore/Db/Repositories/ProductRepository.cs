using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Db.Entities;
using BotApplication.BotStore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.BotStore.Db.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext _db;

        public ProductRepository(StoreContext db)
        {
            _db = db;
        }
        
        public async Task<Product> GetProductById(long id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products
                .OrderBy(Product => Product.Id)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIndex(int index)
        {
            return (await GetAllProducts()).ElementAt(index);
        }
    }
}