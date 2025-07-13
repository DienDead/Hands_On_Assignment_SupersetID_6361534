using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorDetails = $"[{DateTime.Now}] {context.Exception.Message}\n";

        File.AppendAllText("error_log.txt", errorDetails);

        context.Result = new ObjectResult("Internal Server Error - Custom Exception Handler")
        {
            StatusCode = 500
        };
    }
}