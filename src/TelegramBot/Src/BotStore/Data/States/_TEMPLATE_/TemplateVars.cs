using BotFramework.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApplication.BotStore.Data.States._TEMPLATE_
{
    public class _TEMPLATE_Vars
    {
        public static string Introduction = "Привет";
        public static string Unexpected = "ЧТО!#&?";

        public static MarkupBuilder<ReplyKeyboardMarkup> DefaultKeyboardMarkup = new MarkupBuilder<ReplyKeyboardMarkup>()
            .NewRow()
            .Add("Hello")
            .Add("Bye");

    }
}