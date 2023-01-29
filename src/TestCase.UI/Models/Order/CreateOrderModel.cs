using System.ComponentModel.DataAnnotations;

namespace TestCase.UI.Models.Order;

public class CreateOrderModel
{
    public string OrderId { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    public DateTime OrderDate { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    public DateTime ShipDate { get; set; }
    public decimal Sales { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal Profit { get; set; }
}