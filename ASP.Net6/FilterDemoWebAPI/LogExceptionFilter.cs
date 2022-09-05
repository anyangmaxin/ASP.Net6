using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemoWebAPI
{
    public class LogExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            return System.IO.File.AppendAllTextAsync("error.text", context.Exception.ToString()+"\r\n\r\n");
        }
    }
}
