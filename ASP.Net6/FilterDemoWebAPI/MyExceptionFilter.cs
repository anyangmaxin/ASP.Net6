using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemoWebAPI
{
    public class MyExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment env;

        public MyExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.env = webHostEnvironment;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            //返回结果 
            //context.Result

            //异常对象处理
            //context.Exception

            string msg;
            //判断开发环境
            if (this.env.IsDevelopment())
            {
                //开发环境
                msg = context.Exception.ToString();
            }
            else
            {
                msg = "服务器端发生未处理异常";
            }

            ObjectResult objectResult = new ObjectResult(new { code = 500, message = msg });
            //返回结果 
            context.Result = objectResult;
            //标记异常处理
            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
