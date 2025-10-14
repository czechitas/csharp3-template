namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;

public static class ActionResultExtensions
{
    public static T? GetValue<T>(this ActionResult<T> result) => result.Result is null
        ? result.Value
        : (T?)(result.Result as ObjectResult)?.Value;
}
