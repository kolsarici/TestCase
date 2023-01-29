using MediatR;
using TestCase.Contract.Response;

namespace TestCase.Contract.Request.Command;

public class CreateOrderCommand : IRequest<ResponseBase<string>>
{
    public string OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public decimal Sales { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal Profit { get; set; }
}