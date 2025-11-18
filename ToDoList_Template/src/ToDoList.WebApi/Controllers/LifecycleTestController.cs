using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Services;

namespace ToDoList.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LifecycleTestController(
    ILogger<LifecycleTestController> logger,
    IRandomValueServiceScoped scoped1,
    IRandomValueServiceScoped scoped2,
    IRandomValueServiceSingleton singleton1,
    IRandomValueServiceSingleton singleton2,
    IRandomValueServiceTransient transient1,
    IRandomValueServiceTransient transient2) : ControllerBase
{
    [HttpGet]
    public ActionResult Lifecycle()
    {
        logger.LogInformation("New lifecycle test request received.");
        var result = new
        {
            Transient = new
            {
                First = transient1.GetValue(),
                Second = transient2.GetValue()
            },
            Scoped = new
            {
                First = scoped1.GetValue(),
                Second = scoped2.GetValue()
            },
            Singleton = new
            {
                First = singleton1.GetValue(),
                Second = singleton2.GetValue()
            }
        };
        return Ok(result);
    }
}
