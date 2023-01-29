using MediatR;
using TestCase.Contract.Request.Query;
using TestCase.Contract.Response;
using TestCase.Domain;
using TestCase.Domain.OrderAggregate;

namespace TestCase.ApplicationService.Handler.Query;

public class HealthCheckQueryHandler: IRequestHandler<HealthCheckQuery, ResponseBase<string>>
{
    public async Task<ResponseBase<string>> Handle(HealthCheckQuery request, CancellationToken cancellationToken)
    {
        return new ResponseBase<string>()
        {
            Success = true,
            Message = "Alive",
            MessageCode = ApplicationMessage.Success
        };
    }
}