# Assignment 05.1

## Cíl

Ověřit, že dokážeme pracovat s Entity Framework Core takovým způsobem, aby naše WebApi requesty prováděly **CRUD** operace (Vytváření, čtení, úprava a mazání entit) nad naší SQLite databází.

## Zadání

Do naší aplikace přidáváme další funkcionalitu. Aplikace bude umět ukládat úkoly do lokální databáze.

Dokončete úpravu vašeho `ToDoList.WebApi/ToDoItemsController.cs` takovým způsobem, aby dokázal provádět **CRUD** operace nad naší SQLite databází, ke které přistupujeme pomocí Entity Framework Core třídy `ToDoList.Persistence/ToDoItemsContext.cs`. Naše testy budou nyní padat, protože `ToDoList.WebApi/ToDoItemsController.cs` nyní vyžaduje v konstruktoru `ToDoItemsContext.cs`. Je to v pořádku, příští lekci nás čeká přepis našich tříd tak, aby byly testovatelné a izolovatelné.

### ToDoItemsController.cs metoda Create

Tato metoda musí být nově schopna přidat entitu do databáze (contextu) a **uložit ji**.
**TIP:** Nezapomínejte na volání `SaveChanges()` pro ukládání změn.

### ToDoItemsController.cs metoda Get

Tato metoda musí být nově schopna přečíst všechny položky v databázi (contextu) jako `List<ToDoItem>`.
**TIP:** Přistupte k context.ToDoItems a převeďte jej na list.

### ToDoItemsController.cs metoda GetById

Tato metoda musí být nově schopna přečíst konkrétní položku v databázi (contextu) dle dodaného id.
**TIP:** Najděte takovou metodu pod context.ToDoItems. ,která vám pomůže najít vaši konkrétní položku.

### ToDoItemsController.cs metoda Update

Tato metoda musí být nově schopna aktualizovat konkrétní položku v databázi (contextu) dle dodaného id a tuto změnu **uložit**.
**TIP:** Nezapomínejte na volání `SaveChanges()` pro ukládání změn.
**PS:** Existuje vícero způsobů, jak provést update entity v Entity Framework Core, prozkoumejte pečlivě dokumentaci.

### ToDoItemsController.cs metoda DeleteById

Tato metoda musí být nově schopna smazat konkrétní položku v databázi (contextu) dle dodaného id a tuto změnu **uložit**.
**TIP:** Nezapomínejte na volání `SaveChanges()` pro ukládání změn.

## Dodatek / Poznámka

Uvědomte si, že přidáním přímé závislosti na práci s databází (`ToDoItemsContext`) do `ToDoItemsController.cs` měníme současné

`Unit Testy:` testy, které v izolaci testují každou "jednotku"
na
`Integration Testy:` testy, které ověřují chování vícero "jednotek".

V tomto případě se naše aktuální unit testy (pouze testy WebApi) ztransformují na integrační testy, protože nyní ověřují, že **WebApi funguje správně společně s databází**.
