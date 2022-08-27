using System;
using BotApplication.Bot.Db.DbBot;

namespace BotApplication.BotStore.Db.Entities
{
    public class OrderItem : IBaseEntity<long>
    {
        public long Id { get; set; }
        public bool SoftDelete { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }

        
    }
}