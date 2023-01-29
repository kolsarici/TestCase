using TestCase.Domain.OrderAggregate;

namespace TestCase.Repository.RepositoryAggregate;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(TestCaseDbContext context) : base(context)
    {
    }

}