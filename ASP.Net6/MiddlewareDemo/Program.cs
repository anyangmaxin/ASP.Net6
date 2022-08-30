var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
/**
 * Map�ǽӴ�����(����)�����ã����߶�Ӧ��������������Դ��� Use ���м����ÿһ��Map����һ���ŵ�����Ա���ź���Ĺ����ɸ�����ͬ���м�����
 */

//ֻ�ܴ���localhost������
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

//·���м��
app.UseRouting();

//��Ȩ�м��
app.UseAuthorization();

app.MapRazorPages();



app.Run();


