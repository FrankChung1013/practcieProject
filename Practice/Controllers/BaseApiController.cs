using Microsoft.AspNetCore.Mvc;
using Practice.Common.Enum;
using Practice.Repository;

namespace Practice.Controllers;

public class BaseApiController : ControllerBase
{
    protected OkObjectResult Success(string message = MsgCode.Msg00)
    {
        return Ok(new ResponseResult() {Status = Common.Enum.StatusCode.Success, Msg = message});
    }

    protected OkObjectResult Success<T>(T content, string message = MsgCode.Msg00)
    {
        return Ok(new ResponseResult<T>()
        {
            Status = Common.Enum.StatusCode.Success, Msg = message, Data = content
        });
    }

    protected ResponseResult SuccessResult(string message = MsgCode.Msg00)
    {
        return new ResponseResult() {Status = Common.Enum.StatusCode.Success, Msg = message};
    }
    
    protected ResponseResult<T> SuccessResult<T>(T content, string message = MsgCode.Msg00)
    {
        return new ResponseResult<T>() {Status = Common.Enum.StatusCode.Success, Msg = message, Data = content};
    }

    protected OkObjectResult Failure(string message = MsgCode.Msg00)
    {
        return Ok(new ResponseResult() {Status = Common.Enum.StatusCode.Error, Msg = message});
    }

    protected OkObjectResult Failure<T>(T content, string message = MsgCode.Msg01)
    {
        return Ok(new ResponseResult<T>()
        {
            Status = Common.Enum.StatusCode.Error, Msg = message, Data = content
        });
    }

    protected ResponseResult FailureResult(string message = MsgCode.Msg01)
    {
        return new ResponseResult() {Status = Common.Enum.StatusCode.Error, Msg = message};
    }
    
    protected ResponseResult<T> FailureResult<T>(T content, string message = MsgCode.Msg01)
    {
        return new ResponseResult<T>() {Status = Common.Enum.StatusCode.Error, Msg = message, Data = content};
    }
}