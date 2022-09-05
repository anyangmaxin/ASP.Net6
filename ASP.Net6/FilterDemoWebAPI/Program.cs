using FilterDemoWebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注入自定义的Filter
builder.Services.Configure<MvcOptions>(async opt =>
{
    //注意注册顺序 ，否则记录异常日志有问题。
    //opt.Filters.Add<MyExceptionFilter>();
    //opt.Filters.Add<LogExceptionFilter>();
    opt.Filters.Add<MyActionFilter1>();
    opt.Filters.Add<MyActionFilter2>();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
