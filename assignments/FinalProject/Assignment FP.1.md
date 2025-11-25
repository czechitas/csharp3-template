# Assignment FinalProject.1 - Backend

## Cíl

Samostatná práce na aplikaci úpravou backendu

## Zadání

Přidejte třídě `ToDoList.Domain.Models.ToDoItem` novou property

```csharp
public string? Category { get; set; }
```

Náš `ToDoItem` tedy bude mít nově nepovinný string Category.

`Category` je property s typem string? (nullable string). Buď bude property mít hodnotu `null`, což značí, že daný `ToDoItem` kategorii nemá, nebo bude mít hodnotu libovolného `string` (značící kategorii úkolu)

Tato první (větší z hlediska komplexity projektů, menší z hlediska počtu úprav kódu) část úkolu se zabývá pouze backendem.

Je potřeba zapracovat následující požadavky:

- DTOs nově podporují posílání `Category` a převody na/z `ToDoItem` (nevytvářejte nová DTOs, upravte stávající).
- `ToDoItemsContext` a SQLite databáze nově podporuje ukládání a **migraci** nepovinné property `Category` v `ToDoItem` (využijte své znalosti práce s EFCore).
- `ToDoItemsController` nově podporuje posílání DTOs s `Category`.
- `ToDoItemsRepository` ukládá správně `ToDoItem` včetně `Category`.

Zjistíte, že díky tomu, jak máme aplikaci napsanou, nebudete toho muset mnoho upravit, což je super!
Zároveň vám ale nechceme dát přesný postup práce, jelikož si chceme ověřit, že se v dané problematice orientujete a jste schopny samostatné práce.

Nezapomeňte ověřit své WebApi posíláním requestů buď pomocí vašeho `prohlížeče`, `SwaggerUI`, nebo upravte `ToDoItemsRequests.http` abyste si vyzkoušeli posílání a updatování `Category`.

Berte v potaz, že úpravou `ToDoItem` se nám nejspíše rozbijí testy, takže je prosím před odevzdáním opravte.

Ať se daří!
