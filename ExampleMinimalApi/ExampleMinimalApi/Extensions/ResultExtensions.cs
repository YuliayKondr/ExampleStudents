using ExampleApplication.Common;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMinimalApi.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult(
        this Result result,
        int successStatusCode = 200,
        int errorStatusCode = 400)
    {
        if (!result.IsSuccess)
        {
            return (IActionResult) new JsonResult((object) result.ErrorObj)
            {
                StatusCode = errorStatusCode
            };
        }

        return (IActionResult) new JsonResult((object) result)
        {
            StatusCode = successStatusCode
        };
    }

    public static IActionResult ToSimpleActionResult(this Result result)
    {
        return !result.IsSuccess ? (IActionResult) new BadRequestResult() : (IActionResult) new OkResult();
    }
}