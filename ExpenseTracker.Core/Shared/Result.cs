using System;
using System.Net;

namespace ExpenseTracker.Core.Shared;

public class Result<T>
{    
    public T ResultModel { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public HttpStatusCode ErrorCode { get; set; } = HttpStatusCode.OK;

    public bool IsValid
    {
        get { 
            return string.IsNullOrEmpty(ErrorMessage) && ErrorCode is HttpStatusCode.OK; 
        }
    }


    public Result(T resultModel)
    {
        ResultModel = resultModel;
    }

    public Result(string errorMessage, HttpStatusCode errorCode)
    {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }
}
