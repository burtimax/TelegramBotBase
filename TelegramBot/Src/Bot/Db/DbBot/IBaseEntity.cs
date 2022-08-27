using System;

namespace BotApplication.Bot.Db.DbBot
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
        public bool SoftDelete { get; set; }
        DateTimeOffset CreateTime { get; set; }
    }
}