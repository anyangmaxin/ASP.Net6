using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemoWebAPI
{
    public class MyActionFilter2 : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();
            //前代码
            await File.AppendAllTextAsync("error.text", $"{GetType().Name} 前代码 \r\n\r\n");
            //执行下一个筛选器  可以获取 下返回值 判断是否执行成功
            ActionExecutedContext result = await next();
            if (result.Exception != null)
            {
                //说明发生了异常
                await File.AppendAllTextAsync("error.text", $"{GetType().Name} 发生了异常  {result.Exception.ToString()} \r\n\r\n");
            }
            else
            {
                await File.AppendAllTextAsync("error.text", $"{GetType().Name} 执行成功  \r\n\r\n");
            }

            //后代码
            await File.AppendAllTextAsync("error.text", $"{GetType().Name} 后代码 \r\n\r\n");
        }
    }
}
