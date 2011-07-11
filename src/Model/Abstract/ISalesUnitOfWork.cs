namespace Model.Abstract
{
    using Model.Infrastructure;

    public interface ISalesUnitOfWork : IUnitOfWork
    {
        IRepository<Customer> Customers { get; }

        IRepository<Order> Orders { get; }
    }
}
