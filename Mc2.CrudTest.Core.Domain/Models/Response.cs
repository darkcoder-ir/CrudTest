namespace Mc2.CrudTest.Core.Domain.Models;

public class Response
{
    private int StatusCode { get; }
    private string Message { get; }
    private bool IsSuccess { get; }
    private Response(int statusCode, string message, bool isSuccess)
    {
        StatusCode = statusCode;
        Message = message;
        IsSuccess = isSuccess;
    }
    public static Response Create(int statusCode, string message, bool isSuccess)
    {
        return new Response(statusCode, message, isSuccess);
    }
}

public class Response<T>
{
    private int StatusCode { get; }
    private string Message { get; }
    private bool IsSuccess { get; }

    public T? Data { get; set; }

    private Response(T data, int statusCode, string message, bool isSuccess)
    {
        Data = data;
        StatusCode = statusCode;
        Message = message;
        IsSuccess = isSuccess;
    }

    public static Response<T> Create(T data, int statusCode, string message, bool isSuccess)
    {
        return new Response<T>(data, statusCode, message, isSuccess);
    }
}




