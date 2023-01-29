using MediatR;
using TestCase.Contract.Response;

namespace TestCase.Contract.Request.Query;

public class HealthCheckQuery: IRequest<ResponseBase<string>>
{
    
}