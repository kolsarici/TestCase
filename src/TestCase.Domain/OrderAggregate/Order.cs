using TestCase.Domain.Entities;

namespace TestCase.Domain.OrderAggregate;

public class Order : Entity
{
    public string OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public decimal Sales { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal Profit { get; set; }
}