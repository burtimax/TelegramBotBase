using System;
using BotApplication.Bot.Db.DbBot;

namespace BotApplication.BotStore.Db.Entities
{
    public class BasketItem : IBaseEntity<long>
    {
        public long Id { get; set; }
        public bool SoftDelete { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public long UserId { get; set; }
        
        public long ProductId { get; set; }
        virtual public Product Product { get; set; }
        public int Count { get; set; }
        
    }
}