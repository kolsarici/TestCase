using MediatR;
using TestCase.Contract.Response;
using TestCase.Contract.Response.Query;

namespace TestCase.Contract.Request.Query;

public class GetOrdersQuery : IRequest<ResponseBase<ListOrderResponse>>
{
}