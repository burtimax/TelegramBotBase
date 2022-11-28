﻿using System;

namespace TelegramBotTools.Exceptions
{
    public class UnsupportedMessageTypeException : Exception
    {
        public UnsupportedMessageTypeException(string messageType)
        : base($"Unsupported message type [{messageType}]")
        {
        }
    }
}