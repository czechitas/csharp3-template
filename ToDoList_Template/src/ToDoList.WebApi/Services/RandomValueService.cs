namespace ToDoList.WebApi.Services;

public abstract class RandomValueServiceBase : IRandomValueService
{
    private readonly string value;

    protected RandomValueServiceBase(ILogger logger, string typeName)
    {
        value = Guid.NewGuid().ToString();
        logger.LogInformation("{Type} instance created with value: {Value}", typeName, value);
    }

    public string GetValue() => value;
}

// Variants
public class RandomValueServiceTransient : RandomValueServiceBase, IRandomValueServiceTransient
{
    public RandomValueServiceTransient(ILogger<RandomValueServiceTransient> logger)
        : base(logger, nameof(RandomValueServiceTransient)) { }
}

public class RandomValueServiceScoped : RandomValueServiceBase, IRandomValueServiceScoped
{
    public RandomValueServiceScoped(ILogger<RandomValueServiceScoped> logger)
        : base(logger, nameof(RandomValueServiceScoped)) { }
}

public class RandomValueServiceSingleton : RandomValueServiceBase, IRandomValueServiceSingleton
{
    public RandomValueServiceSingleton(ILogger<RandomValueServiceSingleton> logger)
        : base(logger, nameof(RandomValueServiceSingleton)) { }
}
