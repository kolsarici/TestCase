using MediatR;
using TestCase.Contract.Request.Query;
using TestCase.Contract.Response;
using TestCase.Domain;

namespace TestCase.ApplicationService.Handler.Query;

public class HealthCheckQueryHandler: IRequestHandler<HealthCheckQuery, ResponseBase<string>>
{
    public Task<ResponseBase<string>> Handle(HealthCheckQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ResponseBase<string>()
        {
            Success = true,
            Message = "Alive",
            MessageCode = ApplicationMessage.Success
        });
    }
}