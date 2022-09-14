// See https://aka.ms/new-console-template for more information
using TestConsole;

Console.WriteLine("Hello, World!");
var a = new TestCache();
a.SetCache("123", "456");
Console.WriteLine(a.GetCache("123"));
