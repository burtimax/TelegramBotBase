using System;
using System.Collections.Generic;
using BotApplication.Bot.Db.DbBot;

namespace BotApplication.BotStore.Db.Entities
{
    public class Order : IBaseEntity<long>
    {
        public long Id { get; set; }
        public bool SoftDelete { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public long UserId { get; set; }

        virtual public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}