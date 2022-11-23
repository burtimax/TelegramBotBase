using System;
using TelegramBotTools.Models.Message;
using File = Telegram.Bot.Types.File;


namespace TelegramBotTools.MessageData
{
    public class MessageDocument : Models.Message.MessageData
    {
        public string FileName { get; set; }
        public string Caption { get; set; }

        public MessageDocument(string filePath)
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

        public MessageDocument(FileData file, string caption = null)
        {
            this.File = file;
            this.Caption = caption;
        }

        public MessageDocument()
        {

        }
    }
}
