﻿namespace Mc2.CrudTest.Core.Domain.Models;

public class Response
{
    private int StatusCode { get; }
    private string Message { get; }
    private bool IsSuccess { get; }


    protected Response(int statusCode, string message, bool isSuccess)
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

public sealed class Response<TResponse> : Response
{
    private Response(TResponse response, int statusCode, string message, bool isSuccess) : base(statusCode, message,
        isSuccess)
    {
        ResponseObject = response;
    }

    public static Response<TResponse> Create(TResponse response, int statusCode, string message, bool isSuccess)
    {
        return new Response<TResponse>(response, statusCode, message, isSuccess);
    }

    private TResponse? ResponseObject { get; }
}