using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Db.Entities;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApplication.BotStore.Data.States.Main
{
    public class MainVars
    {
        public static string Introduction = "Главное меню";
        public static string Chose = "Выбирай";
        public static string Unexpected = "Не понимаю тебя";

        public static string BasketBtn = "Корзина";
        public static string ProductsBtn = "Товары";

        public static string ShowProductsByProducerNameCallbackPrefix = "ShowProductsByProducerName";
        public static string AddProductToBasketCallbackPrefix = "AddProductToBasket";
        public static string RemoveProductFromBasketCallbackPrefix = "RemoveProductFromBasket";
        public static string ShowAnotherProductCallbackPrefix = "ShowAnotherProduct";
        

        public static MarkupWrapper<ReplyKeyboardMarkup> MainKeyboard = new MarkupWrapper<ReplyKeyboardMarkup>()
            .NewRow()
            .Add(ProductsBtn)
            .Add(BasketBtn);

        
        public static async Task<MarkupWrapper<InlineKeyboardMarkup>> InlineChoseProducer(StoreContext db)
        {
            List<string> producers = await db.Repos.ProducerRepository.GetAllProducers();

            MarkupWrapper<InlineKeyboardMarkup> producersInlineKeyboard = new();

            foreach (var producerName in producers)
            {
                producersInlineKeyboard
                    .NewRow()
                    .Add(producerName, $"{ShowProductsByProducerNameCallbackPrefix}{producerName}");
            }

            return producersInlineKeyboard;
        } 
        
        
        public static async Task<MarkupWrapper<InlineKeyboardMarkup>> ProductInlineMarkup(long userId, StoreContext db, int productIndex)
        {

            List<Product> products = await db.Repos.ProductRepository.GetAllProducts();

            int prev = productIndex - 1;
            if (prev < 0)
            {
                prev = products.Count - 1;
            }

            int next = productIndex + 1;
            if (next >= products.Count)
            {
                next = 0;
            }

            Product product = products.ElementAt(productIndex);
            bool isProductInBasket = await db.Repos.BasketRepository.IsProductInBasket(userId, product.Id);

            string btnCallback = isProductInBasket
                ? RemoveProductFromBasketCallbackPrefix
                : AddProductToBasketCallbackPrefix;
            string btnStr = isProductInBasket ? "Убрать из корзины" : "Добавить в корзину";
            
            MarkupWrapper<InlineKeyboardMarkup> inline = new MarkupWrapper<InlineKeyboardMarkup>();
            inline.NewRow()
                .Add("Пред", $"{ShowAnotherProductCallbackPrefix}:{prev}")
                .Add(btnStr, $"{btnCallback}:{productIndex}")
                .Add("След", $"{ShowAnotherProductCallbackPrefix}:{next}");

            return inline;
        }

        public static string GetProductDescription(Product product)
        {
            StringBuilder desc = new StringBuilder();
            desc.AppendLine($"<b>{product.ProducerName} ({product.Name})</b>");
            desc.AppendLine(product.Description);
            desc.AppendLine($"<b>ЦЕНА {product.Price}</b>");
            return desc.ToString();
        }

    }
}