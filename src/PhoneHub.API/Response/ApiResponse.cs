using System.Text.Json.Serialization;
using ErrorOr;

namespace PhoneHub.API.Response;


public record ApiResponse(
    [property: JsonPropertyName("is-success")]
    bool IsSuccess,
    [property: JsonPropertyName("errors")]
    List<Error>? Errors

)
{
    public static ApiResponse Success() =>
        new(true, null);

    public static ApiResponse Failure(List<Error> errors) =>
        new(false, errors);

    public static ApiResponse Failure(Error error) =>
        new(false, [error]);
}

public record ApiResponse<T>(
    [property: JsonPropertyName("is-success")]
    bool IsSuccess,
    [property: JsonPropertyName("data")]
    T? Data,
    [property: JsonPropertyName("errors")]
    List<Error>? Errors

)
{
    public static ApiResponse<T> Success(T data) =>
        new(true, data, null);

    public static ApiResponse<T> Failure(List<Error> errors) =>
        new(false, default, errors);

    public static ApiResponse<T> Failure(Error error) =>
        new(false, default, [error]);
}
