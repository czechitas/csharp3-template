# Assignment 05.1

## Cíl

Ověřit, že dokážeme pracovat s Entity Framework Core takovým způsobem, aby naše WebApi requesty prováděly **CRUD** operace (Vytváření, čtení, úprava a mazání entit) nad naší SQLite databází.

## Zadání

Do naší aplikace přidáváme další funkcionalitu. Aplikace bude umět ukládat úkoly do lokálního souboru.

Dokončete úpravu vašeho `ToDoItemsController.cs` takovým způsobem, aby dokázal provádět **CRUD** operace nad naší SQLite databází, ke které přistupujeme pomocí Entity Framework Core třídy `ToDoItemsContext.cs`. Ujistěte se, že vaše testy nadále fungují. Pokud ne, je potřeba je opravit. Příští lekci nás čeká přepis našich tříd tak, aby byly testovatelné a izolovatelné.

### ToDoItemsController.cs metoda Create

Tato metoda musí být nově schopna přidat entitu do databáze (contextu) a **uložit ji**.
**TIP:** Nezapomínejte na volání `SaveChanges()` pro ukládání změn.

### ToDoItemsController.cs metoda Get

Tato metoda musí být nově schopna přečíst všechny položky v databázi (contextu) jako `List<ToDoItem>`.

### ToDoItemsController.cs metoda GetById

Tato metoda musí být nově schopna přečíst konkrétní položku v databázi (contextu) dle dodaného id.

### ToDoItemsController.cs metoda Update

Tato metoda musí být nově schopna aktualizovat konkrétní položku v databázi (contextu) dle dodaného id a tuto změnu **uložit**.
**TIP:** Nezapomínejte na volání `SaveChanges()` pro ukládání změn.
**PS:** Existuje vícero způsobů, jak provést update entity v Entity Framework Core, prozkoumejte pečlivě dokumentaci.

### ToDoItemsController.cs metoda DeleteById

Tato metoda musí být nově schopna smazat konkrétní položku v databázi (contextu) dle dodaného id a tuto změnu **uložit**.
**TIP:** Nezapomínejte na volání `SaveChanges()` pro ukládání změn.

## Úprava Testů

Změnami v Controlleru jsme si nyní rozbili testy, kdy konstruktor nyní potřebuje ToDoItemsContext.
Uvědomte si, že přidáním této přímé závislosti na práci s databází pomocí ORM (`ToDoItemsContext`) do `ToDoItemsController.cs` měníme současné

`Unit Testy:` testy, které v izolaci testují každou "jednotku"
na
`Integration Testy:` testy, které ověřují chování vícero "jednotek".

V tomto případě se naše unit testy (pouze testy WebApi) ztransformují na integrační testy, protože nyní ověřují, že **WebApi funguje správně společně s databází**.

### Úprava složek

Pro lepší přehlednost a jednoznačnost si v projektu ToDoList.Tests vytvořte složku `IntegrationTests` a do této nové složky všechny své současné testy přesuňte. V příští hodině si ukážeme, jak se vytváří unit testy bez vnějších závislostí pomocí `Mockování` ;)

### Modifikace testů

Upravte testy tak, aby testovaly funkčnost jednotlivých metod controlleru včetně použití databáze.

Budeme ve svých testech nově potřebovat vytvářet ToDoItemsContext context.
Použijte cestu `Data Source=../../../IntegrationTests/data/localdb_test.db` (odlišnou od té, která je defaultní)
Nezapomeňte vytvořit prázdnou složku `data` s cestou `ToDoList\tests\ToDoList.Test\IntegrationTests\data`, jinak narazíme na chybu, že databázi nelze vytvořit.

Tímto zaručíme, že se nám tzv. produkční databáze s úkoly skutečných uživatelů nepromíchá s "testovací" databází pro naše testy (Budeme tedy mít dvě databáze, localdb.db (produkční, ve složce `ToDoList\data`) a localdb_test.db (testovací, ve složce `ToDoList\tests\ToDoList.Test\IntegrationTests\data`)).

### Testy po sobě musí uklízet

Testy by měly být nestavové a umět si po sobě uklidit (i v databázi). Ujistěte se, že po běhu vašich testů v databázi nic nezůstane (levým poklikem na soubor `localdb_test.db` se díky VSCode rozšíření můžeme podívat co v databázi je - nahoře zvolte tabulku ToDoItems). Pokud v nějakém testu vytváříte objekty, které se ukládají v databázi, musíte je po vykonání testu smazat.

K některým testům tedy přibude nová sekce zodpovědná za úklid daného testu
// Arrange (nachystá test + možné objekty v databázi)
// Act (vykoná testovaný kód/funkcionalitu)
// Assert (ověřuje výstup testovaného kódu)
**// Cleanup** (v této sekci test po sobě pouklízí - například pro nás uklidí v databázi)

TIP: Pokud byste potřebovali "resetovat" vaši databázi, daný soubor .db smažte. (Pokud to nepůjde, buď vám právě běží testy nebo máte otevřený .db file ve svém VSCode - stačí dané okno zavřít)
TIP2: Může se stát, že test napoprvé neprojde (pokud databáze ještě není vytvořená na disku). Tento případ ignorujte (s vytvořenou databází však všechny testy musí procházet).
