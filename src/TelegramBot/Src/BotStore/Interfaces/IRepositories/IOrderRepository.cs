using System.Threading.Tasks;
using BotApplication.BotStore.Db.Entities;

namespace BotApplication.BotStore.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        Task<(Order, string)> CreateOrder(long userId);
    }
}