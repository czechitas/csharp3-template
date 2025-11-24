# BreakoutRoom 09.1

Cíl: Ověřit fungující `ToDoItemsClient.ReadItemsAsync()` v `Dashboard`

Zadání: Zopakujte a ověřte správnost načítání dat z databáze skrze WebAPI s účastnicemi.

- Ověřte správnost registrací tříd `HttpClient` a `ToDoItemClientAsync` do `Dependency Injection Containeru` v `Program.cs`
- Ověřte správnost implementace `ToDoItemClient`
- Ověřte správnost `@inject IToDoItemClient ToDoItemClient` a použití tohoto fieldu správně v `Dashboard.razor`
- Ověřte načítání úkolů v `Dashboard.razor` pomocí `protected override async Task OnInitializedAsync()`
  - Měl by obsahovat následující volání `toDoItemViews = await ToDoItemClient.ReadItemsAsync();`

## Řešení

```csharp
@using ToDoList.Frontend.Views
@using ToDoList.Frontend.Clients

@inject IToDoItemsClient ToDoItemClient
@rendermode InteractiveServer

<div>
    <table>
        <thead>
            <th><button @onclick="OrderById">Id</button></th>
            <th><button @onclick="OrderByName">Name</button></th>
            <th>Description</th>
            <th>IsCompleted</th>
        </thead>
        @if (toDoItemViews is not null)
        {
            @foreach (var item in toDoItemViews)
            {
                <tr>
                    <td>@item.ToDoItemId</td>
                    <td>@item.Name</td>
                    <td>@item.Description</td>
                    <td>@item.IsCompleted</td>
                </tr>
            }
        }
    </table>
</div>

@code
{
    private List<ToDoItemView>? toDoItemViews;
    protected override async Task OnInitializedAsync()
    {
        toDoItemViews = await ToDoItemClient.ReadItemsAsync();
    }

    public void OrderByName()
    {
        toDoItemViews = toDoItemViews?.OrderBy(x => x.Name).ToList();
    }

    public void OrderById()
    {
        toDoItemViews = toDoItemViews?.OrderBy(x => x.ToDoItemId).ToList();
    }
}
```
