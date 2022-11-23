using File = Telegram.Bot.Types.File;

namespace TelegramBotTools.Extensions
{
    public static class FileExtensions
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
