using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Db.Entities;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotTools.Models;
using User = BotApplication.Bot.Db.DbBot.User;

namespace BotApplication.BotStore.Data.States.Basket
{
    public class BasketVars
    {
        public static string Introduction = "Раздел корзины";
        public static string Unexpected = "Не понимаю, что ты хочешь";
        public static string Cleared = "Корзина очищена";
        
        
        public static string BasketBtn = "Корзина";
        public static string ClearBtn = "Очистить корзину";
        public static string OrderBtn = "Отправить заказ";
        public static string MainMenuBtn = "Главное меню";
        
        

        public static async Task<string> GetBasketByUser(StoreContext db, long userId)
        {
            StringBuilder sb = new();

            List<BasketItem> basketItems = await db.Repos.BasketRepository.GetBasketItems(userId);

            if (basketItems == null || basketItems.Count == 0)
            {
                return "Корзина пуста";
            }

            int c = 1;
            int totalPrice = 0;

            sb.AppendLine("Список товаров в корзине");

            foreach (BasketItem basketItem in basketItems)
            {
                Product product = await db.Repos.ProductRepository.GetProductById(basketItem.ProductId);

                sb.AppendLine($"{c}) {product.ProducerName} {product.Name}\n" +
                              $"Цена {product.Price} руб.");
                c++;
                totalPrice += product.Price;
            }

            sb.AppendLine($"\nИтоговая сумма: {totalPrice} руб.");
            return sb.ToString().Trim('\n');
        }

        public static MarkupWrapper<ReplyKeyboardMarkup> BasketKeyboard()
        {
            return new MarkupWrapper<ReplyKeyboardMarkup>()
                .NewRow()
                .Add(BasketBtn)
                .Add(ClearBtn)
                .NewRow()
                .Add(OrderBtn)
                .Add(MainMenuBtn);
        }

        public static async Task<string> GetOrderDescription(StoreContext db, User fromUser, Order order)
        {
            StringBuilder sb = new();
            sb.AppendLine("Новый заказ");
            sb.AppendLine($"От ({fromUser?.TelegramFirstname + " " + fromUser?.TelegramLastname})");
            sb.AppendLine($"Пользователь {fromUser.Id} @{fromUser?.Username}");
            sb.AppendLine();
            sb.AppendLine($"Товары:");

            int c = 1;
            int totalPrice = 0;
            foreach (var item in order.OrderItems)
            {
                Product product = await db.Repos.ProductRepository.GetProductById(item.ProductId);
                sb.AppendLine($"{c}) {product.ProducerName} {product.Name}\n" +
                              $"Цена {product.Price} руб");
                c++;
                totalPrice += product.Price;
            }
            
            sb.AppendLine($"\nИтоговая сумма: {totalPrice} руб.");

            return sb.ToString();
        }

    }
}