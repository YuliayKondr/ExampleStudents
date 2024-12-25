using System.Runtime.Serialization;

namespace ExampleApplication.Common;

[DataContract]
public class Error
{
    public Error()
    {
    }

    public Error(int code, string message)
    {
        ErrorCode = code;
        ErrorMessage = message;
    }

    public int ErrorCode { get; }

    public string ErrorMessage { get; }

    public static Error CreateError(int code, string generalErrorMessage)
    {
        Error error = new Error(code, generalErrorMessage);

        return error;
    }

    public static Error CreateError(string generalErrorMessage)
    {
        Error error = new Error(1, generalErrorMessage);

        return error;
    }
}