using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Db.Entities;
using BotApplication.BotStore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.BotStore.Db.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private StoreContext _db;

        public BasketRepository(StoreContext db)
        {
            _db = db;
        }

        public async Task AddProductToBasket(long userId, Product product)
        {
            List<BasketItem> basketItems = await GetBasketItems(userId);

            if (basketItems.Any(b => b.ProductId == product.Id))
            {
                return;
            }
            
            BasketItem basketItem = new BasketItem()
            {
                UserId = userId,
                Count = 1,
                ProductId = product.Id
            };

            _db.BasketItems.Add(basketItem);
        }

        public async Task<List<BasketItem>> GetBasketItems(long userId)
        {
            return await _db.BasketItems.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task RemoveProductFromBasket(long userId, long productId)
        {
            List<BasketItem> basketItems = await GetBasketItems(userId);

            if (basketItems.Any(b => b.ProductId == productId) == false)
            {
                return;
            }

            BasketItem b = basketItems.First(b => b.ProductId == productId);

            _db.BasketItems.Remove(b);
        }

        public async Task<bool> IsProductInBasket(long userId, long productId)
        {
            List<BasketItem> basketItems = await GetBasketItems(userId);

            if (basketItems.Any(b => b.ProductId == productId))
            {
                return true;
            }

            return false;
        }

        public async Task ClearBasket(long userId)
        {
            List<BasketItem> basketItems = await GetBasketItems(userId);
            _db.BasketItems.RemoveRange(basketItems);
        }
    }
}