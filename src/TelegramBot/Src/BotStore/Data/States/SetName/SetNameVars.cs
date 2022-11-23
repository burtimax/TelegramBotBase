using Telegram.Bot.Types.ReplyMarkups;

namespace BotApplication.BotStore.Data.States.SetName
{
    public class SetNameVars
    {
        public static string Introduction = "Как тебя зовут?";
        public static string Unexpected = "Напиши свое имя пожалуйста)";
        
        public static MarkupWrapper<ReplyKeyboardMarkup> DefaultKeyboardMarkup = new MarkupWrapper<ReplyKeyboardMarkup>()
            .NewRow()
            .Add("Tima")
            .Add("No name", "no_name");

        public static MarkupWrapper<ReplyKeyboardMarkup> GetDefaultValueKeyboard(string defaultName)
        {
            return new MarkupWrapper<ReplyKeyboardMarkup>()
                .NewRow()
                .Add(defaultName);
            
        }

        
    }
}