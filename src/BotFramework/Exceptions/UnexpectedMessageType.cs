using System;

namespace TelegramBotTools.Exceptions
{
    public class UnexpectedMessageType : Exception
    {
        public UnexpectedMessageType() : 
            base("Unexpected message type")
        {
            
        }
    }
}