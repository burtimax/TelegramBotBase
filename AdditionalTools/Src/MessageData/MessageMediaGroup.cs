using System.Collections.Generic;

namespace TelegramBotTools.MessageData
{
    public class MessageMediaGroup
    {
        public List<FileData> Files { get; set; }
        public string Caption { get; set; }

        public MessageMediaGroup()
        {
            this.Files = new List<FileData>();

        }

        public MessageMediaGroup(List<FileData> files)
        {
            this.Files = files;
        }


    }
}
