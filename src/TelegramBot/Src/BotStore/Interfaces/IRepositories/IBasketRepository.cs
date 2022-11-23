using System.Collections.Generic;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Entities;

namespace BotApplication.BotStore.Interfaces.IRepositories
{
    public interface IBasketRepository
    {
        Task AddProductToBasket(long userId, Product product);
        Task<List<BasketItem>> GetBasketItems(long userId);
        Task RemoveProductFromBasket(long userId, long productId);
        Task<bool> IsProductInBasket(long userId, long productId);
        Task ClearBasket(long userId);
    }
}