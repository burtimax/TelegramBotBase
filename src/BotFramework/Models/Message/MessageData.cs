using System;
using System.IO;
using System.Threading.Tasks;
using TelegramBotTools.Exceptions;
using TelegramBotTools.Helpers;

namespace TelegramBotTools.Models.Message
{
    /// <summary>
    /// Базовый класс для файла Telegram 
    /// </summary>
    /// <remarks>Используется при отправке и приеме файлов различных типов в Telegram</remarks>
    public class MessageData
    {
        /// <summary>
        /// Файл
        /// </summary>
        public FileData File { get; set; }
        
        /// <summary>
        /// Заголовок файла
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        /// <param name="filePath"></param>
        public async Task SaveDataToFileAsync(FilePath filePath )
        {
            if (filePath.IsDirectoryExists() == false)
            {
                throw new NotExistingDirectoryException(filePath.DirectoryName);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                 await fs.WriteAsync(this.File.Data,0,this.File.Data.Length);   
            }
        }

        /// <summary>
        /// Считываем данные из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public async Task ReadDataFromFileAsync(FilePath filePath)
        {
            if (filePath.IsFileExists() == false)
            {
                throw new NotExistingFileException(filePath);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                if(this.File.Stream == null)
                {
                    this.File.Data = new byte[Convert.ToInt32(fs.Length)];
                }
                await fs.ReadAsync(this.File.Data, 0, Convert.ToInt32(fs.Length));
            }
        }
    }
}
