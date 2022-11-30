using System;

namespace BotApplication.Bot.Db.DbBot
{
    public class User : IBaseEntity<long>
    {
        /// <summary>
        /// Telegram UserId
        /// </summary>
        public long Id { get; set; }

        public bool SoftDelete { get; set; }

        /// <summary>
        /// Telegram Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Telegram contact phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User role (DEF CurrentUser, moderator, admin, god)
        /// </summary>
        public string Role { get; set; }
        
        /// <summary>
        /// User status (DEF active, block)
        /// </summary>
        public string Status { get; set; }
        
        public string TelegramFirstname { get; set; }
        
        public string TelegramLastname { get; set; }


    
        /// <summary>
        /// Time of creation (datenow())
        /// </summary>
        public DateTimeOffset CreateTime { get; set; }



    }
}
