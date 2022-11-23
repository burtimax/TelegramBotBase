using Telegram.Bot.Types.ReplyMarkups;

namespace BotApplication.BotStore.Data.States.SetAge
{
    public class SetAgeVars
    {
        public static string Introduction = "Сколько тебе лет?";
        public static string Unexpected = "Сколько тебе лет?";

        

        public static MarkupWrapper<ReplyKeyboardMarkup> GetDefaultValueKeyboard(int age)
        {
            return new MarkupWrapper<ReplyKeyboardMarkup>()
                .NewRow()
                .Add(age.ToString());

        }
        
    }
}