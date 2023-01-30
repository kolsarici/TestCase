using MediatR;
using TestCase.Contract.Request.Query;
using TestCase.Contract.Response;
using TestCase.Contract.Response.Query;
using TestCase.Domain.OrderAggregate;

namespace TestCase.ApplicationService.Handler.Query;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ResponseBase<ListOrderResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<ResponseBase<ListOrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var yValues = new List<string>();
        var orders = await _orderRepository.AllAsync(cancellationToken);
        var months = orders.OrderBy(o => o.OrderDate.Month).Select(o => o.OrderDate.Month).Distinct();
        foreach (var month in months)
        {
            yValues.Add(orders.FindAll(o => o.OrderDate.Month == month).Sum(o => o.Quantity).ToString());
        }
        return new ResponseBase<ListOrderResponse>()
        {
            Data = new ListOrderResponse()
            {
                Orders = orders,
                MonthlyOrderCount = new ChartData()
                {
                    X = orders.OrderBy(o => o.OrderDate.Month).Select(o => o.OrderDate.ToString("MMM")).Distinct()
                        .ToArray(),
                    Y = yValues.ToArray()
                }
            },
            Success = true
        };
    }
}