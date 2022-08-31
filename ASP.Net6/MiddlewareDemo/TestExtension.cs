namespace MiddlewareDemo
{
    /// <summary>
    /// 创建一个扩展方法，对IApplicationBuilder进行扩展：
    /// </summary>
    public static class TestExtension
    {
        public static IApplicationBuilder UseTestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddleWare>();
        }
    }
}
