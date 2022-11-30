using BotFramework.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApplication.BotStore.Data.States.ConfirmProfile
{
    public class ConfirmProfileVars
    {
        public static string Introduction = "Это твое письмо тайному санте.\nНорм?";
        public static string Unexpected = "ЧТО!#&?";
        
        public static string BtnNorm = "Норм";
        public static string BtnEdit = "Редактировать";

        public static MarkupBuilder<ReplyKeyboardMarkup> DefaultKeyboardMarkup = new MarkupBuilder<ReplyKeyboardMarkup>()
            .NewRow()
            .Add(BtnNorm)
            .Add(BtnEdit);

    }
}