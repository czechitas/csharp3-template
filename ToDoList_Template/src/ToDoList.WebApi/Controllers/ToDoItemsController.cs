namespace ToDoList.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Audit;
using ToDoList.Persistence.Repositories;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly IRepositoryAsync<ToDoItem> repository;
    private readonly IAudit audit;

    public ToDoItemsController(IRepositoryAsync<ToDoItem> repository, IAudit audit)
    {
        this.repository = repository;
        this.audit = audit;
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItemGetResponseDto>> Create(ToDoItemCreateRequestDto request) => await ExecuteAsync<ToDoItemGetResponseDto>(async () =>
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        await repository.CreateAsync(item);
        //respond to client
        return CreatedAtAction(
            nameof(ReadById),
            new { toDoItemId = item.ToDoItemId },
            ToDoItemGetResponseDto.FromDomain(item)); //201
    });

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItemGetResponseDto>>> Read() => await ExecuteAsync<IEnumerable<ToDoItemGetResponseDto>>(async () =>
    {
        IEnumerable<ToDoItem> itemsToGet;
        itemsToGet = await repository.ReadAllAsync();

        //respond to client
        return (itemsToGet is null)
            ? NotFound() //404
            : Ok(itemsToGet.Select(ToDoItemGetResponseDto.FromDomain)); //200
    });

    [HttpGet("{toDoItemId:int}")]
    public async Task<ActionResult<ToDoItemGetResponseDto>> ReadById(int toDoItemId) => await ExecuteAsync<ToDoItemGetResponseDto>(async () =>
    {
        //try to retrieve the item by id
        ToDoItem? itemToGet;
        itemToGet = await repository.ReadByIdAsync(toDoItemId);

        //respond to client
        return (itemToGet is null)
            ? NotFound() //404
            : Ok(ToDoItemGetResponseDto.FromDomain(itemToGet)); //200
    });

    [HttpPut("{toDoItemId:int}")]
    public async Task<IActionResult> UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request) => await ExecuteAsync(async () =>
    {
        //map to Domain object as soon as possible
        var updatedItem = request.ToDomain();
        updatedItem.ToDoItemId = toDoItemId;

        //retrieve the item
        var itemToUpdate = await repository.ReadByIdAsync(toDoItemId);
        if (itemToUpdate is null)
        {
            return NotFound(); //404
        }

        await repository.UpdateAsync(updatedItem);

        //respond to client
        return NoContent(); //204
    });

    [HttpDelete("{toDoItemId:int}")]
    public async Task<IActionResult> DeleteById(int toDoItemId) => await ExecuteAsync(async () =>
    {
        //try to delete the item
        var itemToDelete = await repository.ReadByIdAsync(toDoItemId);
        if (itemToDelete is null)
        {
            return NotFound(); //404
        }

        await repository.DeleteByIdAsync(toDoItemId);

        //respond to client
        return NoContent(); //204
    });

    private async Task<IActionResult> ExecuteAsync(Func<Task<IActionResult>> action)
    {
        audit.StoreAudit("Metoda zavolana");
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    private async Task<ActionResult<T>> ExecuteAsync<T>(Func<Task<ActionResult<T>>> action)
    {
        audit.StoreAudit("Metoda zavolana");
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }
}
