using BotApplication.Bot.Code;

namespace BotApplication.BotStore.Data
{
    public class StoreBotCommandStorage : BotCommandStorage
    {
        /*
         edit_name - Редактировать имя и фамилию
         edit_photo - Редактировать фоторгафию
         help - Служба поддержки
         change_role - Поменять роль (Организатор/Участник)
         info - Получить инструкцию
         */
        
        public static string ActivityReport = "/get";
        public static string SendMe = "/sendme";
        public static string SendAll = "/sendall";

        protected override void InitCommands()
        {
            //AddStaticCommand(new BotActivityReportCommand(ActivityReport));
            //AddDynamicCommand(new BotTestSendAllCommand(SendMe));
            //AddDynamicCommand(new BotSendAllCommand(SendAll));
        }
    }
}