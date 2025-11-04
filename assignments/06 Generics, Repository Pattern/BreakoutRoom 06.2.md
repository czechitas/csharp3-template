# BreakoutRoom 06.2

Cíl: Ukázat si náhradu ToDoItemsContext pomocí ToDoItemsRepository

Do 2. breakout roomu jsem dal i opakování toho, co spolu uděláme na lekci (ať máme záchytný bod), tak se nelekejte 🙂

1. Vytvořte interface `IRepository<T>` s metodou `public void Create(T)`
2. Vytvořte třídu `ToDoItemsRepository`, která:
   - V konstruktoru přijímá a do private fieldu nastaví `ToDoItemsContext`
   - Implementuje `IRepository<ToDoItem>`
   - Přesuňte `ToDoItemContext` z controlleru do `ToDoItemsRepository`
3. Přidejte repozitář v Program.cs pomocí řádku `builder.Services.AddScoped<IRepository<ToDoItem>, ToDoItemsRepository>();`
4. Napište první unit test pro metodu ToDoListController.Create(), který mockuje `IRepository<ToDoItem>` pomocí Substitute.For<>()
5. Napište druhý unit test pro metodu ToDoListController.Create(), při kterém volání mockRepository.Create() simuluje vyhozenou výjimku (použijte syntax .When().Do())
