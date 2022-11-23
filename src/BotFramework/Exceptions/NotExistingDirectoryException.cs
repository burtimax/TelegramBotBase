using System;

namespace TelegramBotTools.Exceptions
{
    public class NotExistingDirectoryException : Exception
    {
        public NotExistingDirectoryException(string directory) : 
            base($"Directory [{directory}] not exists")
        {
            
        }
    }
}