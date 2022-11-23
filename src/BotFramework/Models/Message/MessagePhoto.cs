using System;
using System.IO;
using TelegramBotTools.Models.Message;
using File = Telegram.Bot.Types.File;

namespace TelegramBotTools.MessageData
{
    public class MessagePhoto
    {
        public FileData File { get; set; }
        public string Caption { get; set; }

        public MessagePhoto(string filePath)
        {
            if(System.IO.File.Exists(filePath) == false)
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
                fs.Close();
            }
        }

        public MessagePhoto(FileData file, string caption = null)
        {
            this.File = file;
            this.Caption = caption;
        }

        public MessagePhoto()
        {

        }
    }
}
