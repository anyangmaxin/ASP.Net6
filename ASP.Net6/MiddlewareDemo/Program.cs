using MiddlewareDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

/**
 * Map是接待客人(请求)的作用：告诉对应的请求，我这里可以处理 Use 是中间件，每一个Map就是一道门的守门员，门后面的功能由各个不同的中间件组成
 */

#region 中间件测试

#region 第一个简单的中间件
//只能处理localhost的请求
//app.MapGet("/", () => "Hello World");

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello World \r\n");
//});

//使用use加入中间件
app.Use(async (context, next) =>
{
    await File.WriteAllTextAsync("a.txt", $"{DateTime.Now.ToString()}");
    await next.Invoke();
});
#endregion

#region 第二种测试中间件
//app.Map("/test", pilebuilder =>
//{
//    pilebuilder.Use(async (context, next) =>
//    {
//        //前代码
//        await context.Response.WriteAsync("Hello World 1 Start \r\n");
//        //await next.Invoke();
//        await next();
//        //后代码
//        await context.Response.WriteAsync("Hellow World 1 End \r\n");
//    });

//    pilebuilder.Use(async (context, next) =>
//    {
//        //前代码
//        await context.Response.WriteAsync("Hello World 2 Start \r\n");
//        //await next.Invoke();
//        await next.Invoke();
//        //后代码
//        await context.Response.WriteAsync("Hellow World 2 End \r\n");
//    });
//    pilebuilder.Run(async context =>
//    {
//        //端点（终点）中间件
//        await context.Response.WriteAsync("+Hellp MiddleWare \r\n");
//    });
//});
#endregion


#region 第三种中间件
//app.UseTestMiddleware();
#endregion

#endregion

//因为执行了run 所以下面的代码不会被 执行。


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//路由中间件
app.UseRouting();

//授权中间件
app.UseAuthorization();

app.MapRazorPages();



app.Run();


