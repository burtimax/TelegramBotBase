using System;
using BotApplication.Bot.Db.DbBot;

namespace BotApplication.BotStore.Db.Entities
{
    public class Product : IBaseEntity<long>
    {
        public long Id { get; set; }
        public bool SoftDelete { get; set; }
        public DateTimeOffset CreateTime { get; set; }

        public string Name { get; set; }
        public string ProducerName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
    }
}