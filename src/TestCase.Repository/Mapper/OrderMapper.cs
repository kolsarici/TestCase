using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCase.Domain.OrderAggregate;

namespace TestCase.Repository.Mapper;

public class OrderMapper: BaseEntityMap<Order>
{
    protected override void Map(EntityTypeBuilder<Order> eb)
    {
        eb.Property(o => o.OrderId).HasColumnType("nvarchar(15)");
        eb.Property(o => o.OrderDate).HasColumnType("datetime");
        eb.Property(o => o.ShipDate).HasColumnType("datetime");
        eb.Property(o => o.Sales).HasColumnType("decimal");
        eb.Property(o => o.Quantity).HasColumnType("int");
        eb.Property(o => o.Discount).HasColumnType("decimal");
        eb.Property(o => o.Profit).HasColumnType("decimal");

        eb.ToTable("Order");
    }
}