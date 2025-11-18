using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
{
    //Configure DI Container
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<ToDoItemsContext>();
    builder.Services.AddScoped<IRepository<ToDoItem>, ToDoItemsRepository>();

    // Lifecycle demo
    builder.Services.AddTransient<IRandomValueServiceTransient, RandomValueServiceTransient>();
    builder.Services.AddScoped<IRandomValueServiceScoped, RandomValueServiceScoped>();
    builder.Services.AddSingleton<IRandomValueServiceSingleton, RandomValueServiceSingleton>();
}

var app = builder.Build();
{
    //Configure Middleware (HTTP request pipeline)
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerUI(config => config.SwaggerEndpoint("v1/swagger.json", "ToDoList API V1"));
}
app.Run();
