using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Interfaces.IRepositories;

namespace BotApplication.BotStore.Db.Repositories
{
    public class RepositoryHub : IRepositoryHub
    {
        private StoreContext _db;
        
        public RepositoryHub(StoreContext db)
        {
            _db = db;
        }

        /// <summary>
        /// ProducerRepository
        /// </summary>
        private ProducerRepository _producerRepository;
        public IProducerRepository ProducerRepository
        {
            get
            {
                if (_producerRepository == null)
                {
                    _producerRepository = new ProducerRepository(_db);
                }

                return _producerRepository;
            }
        }

        /// <summary>
        /// Product repository
        /// </summary>
        private ProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }

                return _productRepository;
            }
        }
        
        
        /// <summary>
        /// Product repository
        /// </summary>
        private BasketRepository _basketRepository;
        public IBasketRepository BasketRepository
        {
            get
            {
                if (_basketRepository == null)
                {
                    _basketRepository = new BasketRepository(_db);
                }

                return _basketRepository;
            }
        }
        
        /// <summary>
        /// Order repository
        /// </summary>
        private OrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }

                return _orderRepository;
            }
        }
        
    }
}