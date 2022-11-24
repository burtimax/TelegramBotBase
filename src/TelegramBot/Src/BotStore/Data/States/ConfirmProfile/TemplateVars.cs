using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotTools.Models;

namespace BotApplication.BotStore.Data.States.ConfirmProfile
{
    public class ConfirmProfileVars
    {
        public static string Introduction = "Это твое письмо тайному санте.\nНорм?";
        public static string Unexpected = "ЧТО!#&?";
        
        public static string BtnNorm = "Норм";
        public static string BtnEdit = "Редактировать";

        public static MarkupWrapper<ReplyKeyboardMarkup> DefaultKeyboardMarkup = new MarkupWrapper<ReplyKeyboardMarkup>()
            .NewRow()
            .Add(BtnNorm)
            .Add(BtnEdit);

    }
}