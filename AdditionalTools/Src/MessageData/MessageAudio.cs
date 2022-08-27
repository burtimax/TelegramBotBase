using System;
using System.IO;
using Telegram.Bot.Types;
using File = Telegram.Bot.Types.File;

namespace TelegramBotTools.MessageData
{
    public class MessageAudio : MessageData
    {

        public string Title { get; set; }
        public InputMedia Thumb { get; set; }

        public MessageAudio(FileData file)
        {
            this.File = file;
        }

        public MessageAudio()
        {

        }


        public MessageAudio(string filePath)
        {
            if (System.IO.File.Exists(filePath) == false)
            {
                throw new Exception("File not found!!!");
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                this.File = new FileData();
                this.File.Data = System.IO.File.ReadAllBytes(filePath);
                this.File.Info = new File();
                this.File.Info.FilePath = filePath;
                this.File.Info.FileSize = this.File.Data.Length;
            }
        }

    }
}