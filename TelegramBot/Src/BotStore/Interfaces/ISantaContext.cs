using BotApplication.BotStore.Db.Entities;
using BotApplication.BotStore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.BotStore.Interfaces
{
    public interface ISantaContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        
        IRepositoryHub Repos { get; }
    }
}