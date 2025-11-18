namespace ToDoList.WebApi.Services;

public interface IRandomValueService
{
    public string GetValue();
}

public interface IRandomValueServiceTransient : IRandomValueService { }
public interface IRandomValueServiceScoped : IRandomValueService { }
public interface IRandomValueServiceSingleton : IRandomValueService { }
