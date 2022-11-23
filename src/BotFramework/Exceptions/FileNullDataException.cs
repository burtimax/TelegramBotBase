using System;

namespace TelegramBotTools.Exceptions
{
    public class FileNullDataException : Exception
    {
        public FileNullDataException() : base("File null data exception")
        {
            
        }
    }
}