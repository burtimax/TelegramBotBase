using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotApplication.BotStore.Interfaces.IRepositories
{
    public interface IProducerRepository
    {
        Task<List<string>> GetAllProducers();
    }
}