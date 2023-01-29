using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCase.Contract.Request.Query;
using TestCase.UI.Models;

namespace TestCase.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<ViewResult> Index()
    {
        var response = await _mediator.Send(new HealthCheckQuery());
        ViewBag.Message = response.Message;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}