var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();





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

/**
 * Map是接待客人(请求)的作用：告诉对应的请求，我这里可以处理 Use 是中间件，每一个Map就是一道门的守门员，门后面的功能由各个不同的中间件组成
 */

#region 中间件测试

#region 第一个简单的中间件
//只能处理localhost的请求
//app.MapGet("/", () => "Hello World");
#endregion

#region 第二种测试中间件
//app.Map("/test", pilebuilder =>
//{
//    pilebuilder.Use(async (context, next) =>
//    {
//        //前代码
//        await context.Response.WriteAsync("Hello World 1 \r\n");
//        //await next.Invoke();
//        await next();
//        //后代码
//        await context.Response.WriteAsync("Hellow World 1 End \r\n");
//    });
//});
#endregion


#endregion

app.Run();


