using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ExampleApplication.Common;

[DataContract]
public class Result
{
    [System.Text.Json.Serialization.JsonIgnore]
    public Error? ErrorObj { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public bool IsSuccess => ErrorObj == null;

    public static Result Success()
    {
        return new Result();
    }

    public static Result Error(Error error)
    {
        return new Result {ErrorObj = error};
    }

    public static Result<T> Error<T>(Error error)
    {
        return Result<T>.Error(error);
    }

    public static Result Error(string generalErrorMessage)
    {
        Error error = Common.Error.CreateError(generalErrorMessage);
        return new Result {ErrorObj = error};
    }

    public static Result<T> Error<T>(string generalErrorMessage)
    {
        Error error = Common.Error.CreateError(generalErrorMessage);
        return new Result<T> {ErrorObj = error};
    }
}

[DataContract]
public sealed class Result<T> : Result
{
    [DataMember(Order = 1)]
    [JsonProperty("data")]
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    public static Result<T> Success(T? data)
    {
        return new Result<T> { Data = data};
    }

    public new static Result<T> Error(Error error)
    {
        return new Result<T> {ErrorObj = error};
    }
}