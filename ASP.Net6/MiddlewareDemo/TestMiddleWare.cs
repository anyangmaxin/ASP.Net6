namespace MiddlewareDemo
{
    public class TestMiddleWare
    {
        /**
         * ASP.NET Core约定中间件类必须包括以下内容：

具有类型为RequestDelegate参数的公共构造函数。

必须有名为Invoke或InvokeAsync的公共方法，此方法必须满足两个条件：方法返回类型是Task、方法的第一个参数必须是HttpContext类型。
        */

        private readonly RequestDelegate _next;

        public TestMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await File.AppendAllTextAsync("a.txt", $"TestMiddleWare 执行前代码 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} \r\n");
            //前代码

            //调用管道中的下一个委托
            await this._next.Invoke(httpContext);
            //后代码
            await File.AppendAllTextAsync("a.txt", $"TestMiddleWare 执行后代码 {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} \r\n");
        }

    }
}
