using MediatR;
using TestCase.Contract.Response;

namespace TestCase.Contract.Request.Query;

public class LoginQuery: IRequest<ResponseBase<bool>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}