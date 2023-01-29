using System.Net;

namespace TestCase.Domain;

[Serializable]
public class BusinessRuleException : Exception
{
    public string Code { get; set; }
    public new string Message { get; set; }
    public string UserMessage { get; set; }
    public HttpStatusCode? HttpResponseCode { get; private set; }

    protected BusinessRuleException()
    {
    }

    public BusinessRuleException(
        string code,
        string message,
        string userMessage,
        HttpStatusCode? httpResponseCode = null)
        : base(message)
    {
        Code = code;
        Message = message;
        UserMessage = userMessage;
        HttpResponseCode = httpResponseCode;
    }

    protected BusinessRuleException(string message)
        : base(message)
    {
    }
}