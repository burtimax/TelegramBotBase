using System.Collections.Generic;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Db.Entities;
using BotApplication.BotStore.Interfaces.IRepositories;

namespace BotApplication.BotStore.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private StoreContext _db;

        public OrderRepository(StoreContext db)
        {
            _db = db;
        }

        public async Task<(Order, string)> CreateOrder(long userId)
        {
            List<BasketItem> basketItems = await _db.Repos.BasketRepository.GetBasketItems(userId);

            if (basketItems == null || basketItems.Count == 0)
            {
                return (null, "Нельзя отправить заказ, ваша корзина пуста.");
            }
            
            Order order = new()
            {
                UserId = userId,
            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            foreach (BasketItem basketItem in basketItems)
            {
                order.OrderItems.Add(new OrderItem()
                {
                    Count = 1,
                    OrderId = order.Id,
                    ProductId = basketItem.ProductId
                });
            }

            await _db.Repos.BasketRepository.ClearBasket(userId);
            await _db.SaveChangesAsync();
            return (order, "Заказ отправлен");
        }
    }
}