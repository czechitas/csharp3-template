namespace ToDoList.WebApi.Middlewares;
using System.Diagnostics;

public class TimingMiddleware(RequestDelegate requestDelegate)
{
    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await requestDelegate(context);
        stopwatch.Stop();
        Console.WriteLine($"Request to {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms.");
    }
}
