# BreakoutRoom 08.2

- Nastavte interaktivní server mode v `Program.cs`

  ```csharp
  // je potřeba upravit kód v Program.cs následovně
  builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();
  // a také
  app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();
  ```

- Nastavte interaktivní server mode v `Home.razor` pomocí `@rendermode InteractiveServer`
- Přidejte tlačítko  `<button @onclick="IncrementCounter">JmenoTlacitka</button>`
- Implementujte funkci `IncrementCounter()`
- Vytvořte novou komponentu `Dashboard`, kterou zavoláte z `Home.razor`
- Vytvořte si `ToDoItemView` třídu a v `Dashboard` komponentě si pro ní vytvořte testovací data
- Pro všechna testovací data vykreslete tabulku
