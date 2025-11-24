# Assignment 09.1

## Cíl

Procvičit si přepis na asynchronní metody, ujasnit si používání a syntax asynchronních metod.

## Zadání

Upravte `ToDoItemsController`, `IRepository`, `ToDoItemsRepository` tak, abychom z aktuálních synchronních volání metod udělali asynchronní.

### 1. Úprava `IRepository`

V souboru `IRepository.cs` vytvořte nový interface `IRepositoryAsync`.Tento nový interface bude obsahovat stejné metody jako interface `IRepository`, ale bude asynchronní.
Metody budou mít návratový typ `Task` (v případě metody, která vrací void) nebo `Task<ReturnValue>` (kde ReturnValue je návratový typ synchronní "verze" metody).

Všimněte si, že `IRepositoryAsync` se od `IRepository` liší pouze "zabalením" metod do Task<> (případně náhradou návratového typu void za Task).

Klíčové slovo `async` **v definicích metod v interfacu nepoužíváme**, použijeme jej až v dalších bodech při úpravě `ToDoItemsRepository` a `ToDoItemsController`.
Klíčové slovo `async` "pouze" **modifikuje chování metody**, konkrétně specifikuje možnost asynchronního vykonání dané metody.

### 2. Úprava `ToDoItemsRepository`

V souboru `ToDoItemsRepository.cs` vyměňte volání synchronních metod `context.ToDoItems.***` za jejich asynchronní verze (stačí připsat Async a před voláním použít `await` ;) ).
TIP: Metoda `Remove()` ani `SetValue()` asynchronní variantu nemají (tyto metody pouze označují odstranění/úpravu entity), takže je nemusíte hledat ;). Změny se propisují do databáze asynchronně až při `SaveChangesAsync()`

Na všechny asynchronní volání metod použijte klíčové slovo `await`.
Tímto zaručíme, že naše volání do databáze **nebude blokovat volajícího**, který může vykonávat další Tasky, zatímco čeká na náš výsledek.

Změňte děděný interface na `IRepositoryAsync`.

Upravte metody klíčovým slovem `async` a nastavte návratovové typy na `Task` (v případě metody, která vrací void) nebo `Task<ReturnValue>` (kde ReturnValue je návratový typ synchronní verze metody).

### 3. Úprava `ToDoItemsController`

Vyměňte v konstruktoru `IRepository` za `IRepositoryAsync`.
Jelikož v `ToDoItemsController` nyní voláme asynchronní metody repozitáře `IRepositoryAsync`, potřebujeme náš controller upravit tak, aby také podporoval asynchronní volání.

Nahraďte současná volání `repository.*` za asynchronní, vytvořená v předchozím bodě úpravou `ToDoItemsRepository`.
Na všechny asynchronní volání metod použijte klíčové slovo `await`.
Tímto zaručíme, že naše volání do repozitáře **nebude blokovat volajícího**, který může vykonávat další Tasky, zatímco čeká na náš výsledek.

Nastavte návratové typy metod `ToDoItemsController` na `Task` (v případě metody, která vrací void) nebo `Task<ReturnValue>` (kde ReturnValue je návratový typ synchronní verze metody).

### 4. Oprava testů

Opravte všechny nyní padající testy.
Je potřeba testovací metody modifikovat klíčovým slovem `async` a použít `await` u každého volání asynchronní metody. Kdyby byl nějaký problém, hned pište na Discord do #otázky
