using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.BotStore.Db.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private StoreContext _db;

        public ProducerRepository(StoreContext db)
        {
            _db = db;
        }

        public async Task<List<string>> GetAllProducers()
        {
            return await _db.Products.Select(p => p.ProducerName).Distinct().ToListAsync();
        }
    }
}