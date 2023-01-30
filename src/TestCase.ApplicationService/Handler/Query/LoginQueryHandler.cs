using MediatR;
using TestCase.Contract.Request.Query;
using TestCase.Contract.Response;
using TestCase.Domain;

namespace TestCase.ApplicationService.Handler.Query;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ResponseBase<bool>>
{
    public async Task<ResponseBase<bool>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (request.Username == "kolsarici" && request.Password == "123")
        {
            return new ResponseBase<bool>()
            {
                Success = true
            };
        }

        return new ResponseBase<bool>()
        {
            Success = false,
            UserMessage = ApplicationMessage.InvalidLogin.UserMessage(),
            Message = ApplicationMessage.InvalidLogin.Message(),
            MessageCode = ApplicationMessage.InvalidLogin
        };
    }
}