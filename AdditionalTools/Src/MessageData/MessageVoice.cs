﻿using System;
using File = Telegram.Bot.Types.File;

namespace TelegramBotTools.MessageData
{
    public class MessageVoice : MessageData
    {

        public MessageVoice(FileData file)
        {
            this.File = file;
        }

        public MessageVoice()
        {
        }

        public MessageVoice(string filePath)
        {
            if (System.IO.File.Exists(filePath) == false)
            {
                throw new Exception("File not found!!!");
            }

            
            this.File = new FileData();
            this.File.Data = System.IO.File.ReadAllBytes(filePath);
            this.File.Info = new File();
            this.File.Info.FilePath = filePath;
            this.File.Info.FileSize = this.File.Data.Length;
        
        }
    }
}