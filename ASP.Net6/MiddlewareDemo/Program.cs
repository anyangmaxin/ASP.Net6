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

//·���м��
app.UseRouting();

//��Ȩ�м��
app.UseAuthorization();

app.MapRazorPages();

/**
 * Map�ǽӴ�����(����)�����ã����߶�Ӧ��������������Դ��� Use ���м����ÿһ��Map����һ���ŵ�����Ա���ź���Ĺ����ɸ�����ͬ���м�����
 */

#region �м������

#region ��һ���򵥵��м��
//ֻ�ܴ���localhost������
//app.MapGet("/", () => "Hello World");
#endregion

#region �ڶ��ֲ����м��
//app.Map("/test", pilebuilder =>
//{
//    pilebuilder.Use(async (context, next) =>
//    {
//        //ǰ����
//        await context.Response.WriteAsync("Hello World 1 \r\n");
//        //await next.Invoke();
//        await next();
//        //�����
//        await context.Response.WriteAsync("Hellow World 1 End \r\n");
//    });
//});
#endregion


#endregion

app.Run();


