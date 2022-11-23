using System;

namespace TelegramBotTools.Exceptions
{
    public class NotExistingFileException : Exception
    {
        public NotExistingFileException(string filePath) : 
            base($"File [{filePath}] not exists")
        {
            
        }
    }
}