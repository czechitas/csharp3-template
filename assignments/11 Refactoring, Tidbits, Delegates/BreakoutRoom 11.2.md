# BreakoutRoom 11.2

Cíl: Naučit se práci s Func<> a jednoduchými lambdami.

Zadání:

- Vytvořte field `CurrentFilter` typu Func<ToDoItemView, bool>.

- "By default" by měl tento filtr pro každý vstup vracet `true`. Zajistěte toto inicializací pomocí lambda výrazu.

```csharp
(itemView) => {return true;}

// případně zkráceně pomocí expression lambdy
(itemView) => true;
```

- Vytvořte následující metody s prázdnou implementací:
`ShowAll()`
`ShowCompleted()`
`ShowIncomplete()`

- Implamentujte nastavení `CurrentFilter` v těle těchto metod pomocí lambda výrazu
  - pro `ShowAll()` - použitý lambda výraz vrací vždy `true`
  - pro `ShowCompleted()` - použitý lambda výraz vrací `true` pouze pro splněné úkoly
  - pro `ShowIncomplete()` - použitý lambda výraz vrací `true` pouze pro nesplněné úkoly

- Do HTML části pod tabulku přidejte nová tlačítka:

```csharp
<button class="btn btn-success" @onclick="ShowAll">Show All</button>
<button class="btn btn-success" @onclick="ShowCompleted">Show Completed</button>
<button class="btn btn-success" @onclick="ShowIncomplete">Show Incomplete</button>
```

- Upravte ve @foreach logiku tak, aby filtrovala úkoly podle `CurrentFilter`

- Vyzkoušejte funkcionalitu poklikem na jednotlivá tlačítka.
