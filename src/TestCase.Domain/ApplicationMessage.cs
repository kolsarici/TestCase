namespace TestCase.Domain;

public static class ApplicationMessage
{
    private const string CommonUserErrorMessage =
        "İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz.";

    public static string UnhandledError = "CAT_-1";
    public static readonly string Success = "CAT_0";
    public static string TimeoutOccurred = "CAT_55";
    public static string UnExpectedHttpResponseReceived = "CAT_56";


    private static readonly Dictionary<string, string> ErrorMessages =
        new Dictionary<string, string>()
        {
            {UnhandledError, "Unhandled exception."},
            {Success, "İşlem Başarıyla Gerçekleştirildi."},
            {TimeoutOccurred, "Timeout oluştu."},
            {UnExpectedHttpResponseReceived, "Beklenmedik bir httpCode ile response alındı."},
        };

    private static readonly Dictionary<string, string> UserMessages =
        new Dictionary<string, string>()
        {
            {UnhandledError, CommonUserErrorMessage},
            {Success, "İşlem Başarıyla Gerçekleştirildi."},
            {TimeoutOccurred, "Timeout oluştu."},
            {UnExpectedHttpResponseReceived, "Beklenmedik bir httpCode ile response alındı."},
        };

    public static string Message(this string code)
    {
        ErrorMessages.TryGetValue(code, out var errorMessage);
        return errorMessage;
    }

    public static string UserMessage(this string code)
    {
        UserMessages.TryGetValue(code, out var errorMessage);
        return errorMessage;
    }
}