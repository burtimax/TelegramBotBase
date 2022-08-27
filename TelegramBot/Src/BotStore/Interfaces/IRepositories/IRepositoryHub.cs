namespace BotApplication.BotStore.Interfaces.IRepositories
{
    public interface IRepositoryHub
    {
        IProducerRepository ProducerRepository { get; }
        IProductRepository ProductRepository { get; }
        IBasketRepository BasketRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}