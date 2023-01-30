using MediatR;
using TestCase.Contract.Request.Command;
using TestCase.Contract.Response;
using TestCase.Domain;
using TestCase.Domain.OrderAggregate;

namespace TestCase.ApplicationService.Handler.Command;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseBase<string>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDbContextHandler _dbContextHandler;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IDbContextHandler dbContextHandler)
    {
        _orderRepository = orderRepository;
        _dbContextHandler = dbContextHandler;
    }

    public async Task<ResponseBase<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.SaveAsync(new Order()
        {
            Id = Guid.NewGuid(),
            OrderId = request.OrderId,
            Discount = request.Discount,
            Profit = request.Profit,
            OrderDate = request.OrderDate,
            Sales = request.Sales,
            ShipDate = request.ShipDate,
            Quantity = request.Quantity
        }, cancellationToken);
        await _dbContextHandler.SaveChangesAsync();
        return new ResponseBase<string>()
        {
            Success = true,
            Message = ApplicationMessage.Success
        };
    }
}