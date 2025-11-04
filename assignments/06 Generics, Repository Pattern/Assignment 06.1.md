# Assignment 06.1

## Cíl

Vyzkoušet si implementaci Repository vzoru, oddělit závislost na datové vrstvě a znovu umožnit unit testování.

## Zadání

Podobně jako jsme si naimplementovali `Create` metodu pro náš repozitář, dokončete implementaci pro ostatní metody z našeho controlleru. Na závěr můžeme úspěšně odstranit závislost na `ToDoItemsContext` z controlleru a spoléhat pouze na repozitář. Pro opakování, toto byly naše kroky pro `Create`:

- Vytvořte interface `IRepository<T>` s metodou `Create(T)`
- Vytvořte třídu `ToDoItemsRepository`, která:
- V konstruktoru přijme a nastaví `ToDoItemContext`
- Implementuje `IRepository<ToDoItem>`
- Přesuňte použití `ToDoItemContext` z controlleru do repository
- Nastavte DI pomocí `builder.Services.AddScoped<IRepository<ToDoItem>, ToDoItemsRepository>();`
