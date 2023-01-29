using Microsoft.AspNetCore.Mvc;
using MediatR;
using TestCase.Contract.Request.Command;
using TestCase.Contract.Request.Query;
using TestCase.UI.Models.Order;

namespace TestCase.UI.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IMediator _mediator;

    public OrderController(ILogger<OrderController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Index()
    {
        var response = await _mediator.Send(new GetOrdersQuery());
        return View(response);
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderModel createOrderModel)
    {
        var response = await _mediator.Send(new CreateOrderCommand()
        {
            OrderId = createOrderModel.OrderId,
            OrderDate = createOrderModel.OrderDate,
            ShipDate = createOrderModel.ShipDate,
            Discount = createOrderModel.Discount,
            Profit = createOrderModel.Profit,
            Quantity = createOrderModel.Quantity,
            Sales = createOrderModel.Sales
        });
        return RedirectToAction("Index");
    }
}