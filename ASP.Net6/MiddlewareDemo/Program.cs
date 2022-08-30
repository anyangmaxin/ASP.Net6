var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
/**
 * Map是接待客人(请求)的作用：告诉对应的请求，我这里可以处理 Use 是中间件，每一个Map就是一道门的守门员，门后面的功能由各个不同的中间件组成
 */

//只能处理localhost的请求
app.MapGet("/", () => "Hello World");
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


