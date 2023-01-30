namespace TestCase.Domain;

public static class ApplicationMessage
{
    private const string CommonUserErrorMessage = "Unhandled exception has been raised. Please try again later.";

    public static string UnhandledError = "TEC_-1";
    public static readonly string Success = "TEC_0";
    public static string TimeoutOccurred = "TEC_1";
    public static string UnExpectedHttpResponseReceived = "TEC_2";
    public static string InvalidLogin = "TEC_3";


    private static readonly Dictionary<string, string> ErrorMessages =
        new Dictionary<string, string>()
        {
            {UnhandledError, "Unhandled exception."},
            {Success, "Success"},
            {TimeoutOccurred, "Timeout occured"},
            {UnExpectedHttpResponseReceived, "Unexpected error"},
            {InvalidLogin, "Invalid Login"},
        };

    private static readonly Dictionary<string, string> UserMessages =
        new Dictionary<string, string>()
        {
            {UnhandledError, CommonUserErrorMessage},
            {Success, "Successfully processed."},
            {TimeoutOccurred, "Timeout occured."},
            {UnExpectedHttpResponseReceived, "Unexpected error has been received. Please try again later."},
            {InvalidLogin, "Username or password is incorrect!"},
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