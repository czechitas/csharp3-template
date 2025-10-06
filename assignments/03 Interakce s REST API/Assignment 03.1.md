# Assignment 03.1

## Naimplementuj základní ToDoItemsController REST API

### Cíl

Tvůj cíl je naimplementovat CRUD operace pro náš ToDoList úkolový systém. Metody již máme vydefinované, ale jsou aktuálně prázdné či nedostačující. Je na tobě doplnit kód tohoto ToDoItems REST API tak, aby odpovídal zadání a dokázal tak obsloužit HTTP requesty, které mu budou klienti posílat.

### Instrukce

#### Předpoklady na tvůj projekt

- Předpokládá se, že tvůj projekt již má správně vytvořené projekty, složky a soubory.
- Třída `ToDoItemsController` je již vytvořená, přidaná do aplikace a obsahuje všechny metody (**Create**, **Read**, **ReadById**, **UpdateById**, **DeleteById**)
- Předpokládá se, že tvůj projekt obsahuje třídu `ToDoItem` v projektu `ToDoList.Domain`
- Třída `ToDoItemsController` obsahuje field `private static readonly List<ToDoItem> items = [];`, pokud ne, vytvoř si jej.

#### Doimplementuj metody

Doplň kód do metod v třídě `ToDoItemsController`. Specifikace je níže.

## Specifikace Metod

### 1. Create a ToDo Item

- **Method:** `Create`
- **HTTP Method:** `POST`
- **Route:** `/api/ToDoItems`
- **Request Body:** `ToDoItemCreateRequestDto`
- **Response:**
  - `201 Created`
  - `500 Internal Server Error`, pokud nastane jakákoliv výjimka.
  - **Extra (nepovinné):** Použij `CreatedAtAction`, abys vrátila vytvořený předmět společně s cestou kde se dá najít a s jeho ID.
- **TIP:**
  - Přelož si nejdříve DTO na model pomocí metody `ToDoItemCreateRequestDto.ToDomain()` (vytvoř si tuto metodu)
  - Pro přidání instance třídy ToDoItem do listu úkolů použij metodu `.Add()` (vyhledej jak se používá)
  - Pokud si nevíš rady, mrkni na konec tohoto souboru, je tam ukázána vzorová implementace.

### 2. Retrieve All ToDo Items

- **Method:** `Read`
- **HTTP Method:** `GET`
- **Route:** `/api/ToDoItems`
- **Response:**
  - `200 OK` s listem všech úkolů ve formě DTO `List<ToDoItemGetResponseDto>`
  - `404 Not Found`, pokud je list úkolů `null`
  - `500 Internal Server Error`, pokud nastane jakákoliv výjimka.
- **TIP:**
  - Pro přidání instance třídy ToDoItem do listu úkolů použij metodu `.Add()` (vyhledej jak se používá)

### 3. Retrieve a ToDo Item by ID

- **Method:** `ReadById`
- **HTTP Method:** `GET`
- **Route:** `/api/ToDoItems/{toDoItemId}`
- **Path Parameter:** `toDoItemId` (int)
- **Response:**
  - `200 OK` s takovým úkolem, jehož id odpovídá parametru cesty `toDoItemId` (žádané id odpovídá id daného úkolu)
    - Úkol je navrácen ve formátu `ToDoItemGetResponseDto`!
  - `404 Not Found`, pokud daný úkol neexistuje.
  - `500 Internal Server Error`, pokud nastane jakákoliv výjimka.
- **TIP:**
  - Pro prohledání listu úkolů použij LINQ metodu `.Find()` (vyhledej jak se používá)

### 4. Update a ToDo Item

- **Method:** `UpdateById`
- **HTTP Method:** `PUT`
- **Route:** `/api/ToDoItems/{toDoItemId}`
- **Path Parameter:** `toDoItemId` (int)
- **Request Body:** `ToDoItemUpdateRequestDto`
- **Response:**
  - `204 No Content`, pokud se povede daný úkol aktualizovat.
  - `404 Not Found`, pokud daný úkol neexistuje.
  - `500 Internal Server Error`, pokud nastane jakákoliv výjimka.
- **TIP:**
  - Jak updatovat úkol
    - Vytvoř si novou "updatovanou" instanci pomocí metody `ToDoItemUpdateRequestDto.ToDomain()` (vytvoř si tuto metodu)
    - Najdi, jestli se "aktuální" instance nachází v listu úkolů
    - Najdi na kterém indexu v listu se nachází "aktuální" instance pomocí LINQ `.FindIndex()` (vyhledej jak se používá)
    - Poté proveď update přepisem instance na nalezeném indexu (items[indexOfOldInstance] = updatedItem)

### 5. Delete a ToDo Item by ID

- **Method:** `DeleteById`
- **HTTP Method:** `DELETE`
- **Route:** `/api/ToDoItems/{toDoItemId}`
- **Path Parameter:** `toDoItemId` (int)
- **Response:**
  - `204 No Content`, pokud se povede daný úkol smazat.
  - `404 Not Found`, pokud daný úkol neexistuje.
  - `500 Internal Server Error`, pokud nastane jakákoliv výjimka.
- **TIP:**
  - Pro prohledání listu úkolů použij LINQ metodu `.Find()` (vyhledej jak se používá)

## Ukázka DTOs and Modelu

### ToDoItem.Model ToDoItemCreateRequestDto

```csharp
public record ToDoItemCreateRequestDto(string Name, string Description, bool IsCompleted) //id is generated
{
    public ToDoItem ToDomain() => new() { Name = Name, Description = Description, IsCompleted = IsCompleted };
}
```

### ToDoItem.Model ToDoItemGetResponseDto

```csharp
public record ToDoItemGetResponseDto(int Id, string Name, string Description, bool IsCompleted) //let client know the Id
{
    public static ToDoItemGetResponseDto FromDomain(ToDoItem item) => new(item.ToDoItemId, item.Name, item.Description, item.IsCompleted);
}
```

### ToDoItem.Model ToDoItem

```csharp
public class ToDoItem
{
    public int ToDoItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
```

## Ukázka implementace Create metody v MVC Controlleru

```csharp
namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("[controller]")]
public class ToDoItemsController : ControllerBase
{
    private static List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            item.ToDoItemId = items.Count == 0 ? 1 : items.Max(o => o.ToDoItemId) + 1;
            items.Add(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return Created(); //201 //tato metoda z nějakého důvodu vrací status code No Content 204, zjištujeme proč ;)
    }

    [HttpGet]
    public IActionResult Read()
    {

    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {

    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {

    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {

    }
}
```

Good luck and happy coding!
