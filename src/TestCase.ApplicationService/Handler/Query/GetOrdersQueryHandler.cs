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

    public async Task<ResponseBase<ListOrderResponse>> Handle(GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orderCountYValues = new List<string>();
        var salesSumYValues = new List<string>();
        var orders =
            await _orderRepository.FilterByAsync(o => o.OrderDate > DateTime.Today.AddYears(-1), cancellationToken);
        var months = orders.OrderBy(o => o.OrderDate.Year).ThenBy(o => o.OrderDate.Month).Select(o => o.OrderDate.Month)
            .Distinct();
        var xValues = orders.OrderBy(o => o.OrderDate.Year).ThenBy(o => o.OrderDate.Month)
            .Select(o => o.OrderDate.ToString("MMM")).Distinct()
            .ToArray();
        foreach (var month in months)
        {
            orderCountYValues.Add(orders.FindAll(o => o.OrderDate.Month == month).Sum(o => o.Quantity).ToString());
        }

        foreach (var month in months)
        {
            salesSumYValues.Add(orders.FindAll(o => o.OrderDate.Month == month).Sum(o => o.Sales).ToString());
        }

        return new ResponseBase<ListOrderResponse>()
        {
            Data = new ListOrderResponse()
            {
                Orders = orders,
                MonthlyOrderCount = new ChartData()
                {
                    X = xValues,
                    Y = orderCountYValues.ToArray()
                },
                MonthlySaleSum = new ChartData()
                {
                    X = xValues,
                    Y = salesSumYValues.ToArray()
                }
            },
            Success = true
        };
    }
}