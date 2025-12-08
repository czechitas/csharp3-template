# BreakoutRoom 11.1

Cíl: Vyzkoušet si naprogramovat jednoduchého delegáta.

Zadání:

- Zadefinujte delegáta v `EditToDoItem.razor`, který vrací `void` a přijímá jako parametr `ToDoItemView`. Pojmenujte jej `ToDoItemViewProcessingDelegate`

- Vytvořte field typu `ToDoItemViewProcessingDelegate` (náš zadefinovaný delegát) se jménem `SubmitDelegate`

- Vytvořte metodu `LogSubmit`, která odpovídá předpisu delegáta typu `ToDoItemViewProcessingDelegate`. V této metodě pomocí formátovaného textu zapište do konzole, jaká hodnota `ToDoItemView.ToDoItemId` byl submitnut.

- V metodě `Submit`, která se stará o zpracování dat po kliknutí na tlačítko "submit" budeme chtít zavolat našeho `SubmitDelegate`, použijte `()` nebo `.Invoke()`

- Pokuste se spustit program, co se pokazí?

- V metodě `OnInitializedAsync()` přidejte registraci naší metody `LogSubmit` do našeho `SubmitDelegate`.

- Program by měl nyní fungovat a do konzole se po stisknutí "submit" tlačítka vpíše do konzole, který `ToDoItemView.ToDoItemId` byl submitnut.

## Extra

- Zkuste si svou `LogSubmit` metodu zaregistrovat do `SubmitDelegate` vícekrát. Co se bude dít?
- Zkuste si svou `LogSubmit` metodu právě jednou zaregistrovat, a poté právě jednou odregistrovat. Co se bude dít?
- V metodě `Submit()` upravte volání našeho delegáta tak, aby byl "null-safe".
