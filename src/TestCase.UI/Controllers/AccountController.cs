using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCase.Contract.Request.Query;
using TestCase.UI.Models.Account;

namespace TestCase.UI.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IMediator _mediator;

    public AccountController(ILogger<AccountController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel loginModel, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new LoginQuery()
        {
            Username = loginModel.Username,
            Password = loginModel.Password
        }, cancellationToken);
        if(response.Success)
            return RedirectToAction("Index", "Order");
        return RedirectToAction("Index");
        
    }
}