using File = Telegram.Bot.Types.File;

namespace TelegramBotTools.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get file extension (File class)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileExtension(this File file)
        {
            string path = file.FilePath;
            return path.Substring(path.LastIndexOf('.'));
        }

    }
}
