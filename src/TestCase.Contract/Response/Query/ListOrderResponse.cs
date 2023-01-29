using TestCase.Domain.OrderAggregate;

namespace TestCase.Contract.Response.Query;

public class ListOrderResponse
{
    public List<Order> Orders { get; set; }
    public ChartData ChartData { get; set; }
}

public class ChartData
{
    public string[] X { get; set; }
    public string[] Y { get; set; }
}