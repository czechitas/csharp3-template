# Assignment 02.1 (povinný)

Cíl: Rozběhnout svůj první webový projekt a vyzkoušet si, jak fungují webové stránky.

Zadání: Ahoj, pokud jste narazily na problém s vytvořením nového webového projektu, raději tedy zasílám nový návod :) Pokud máte svůj projekt ToDoList.WebApi rozjetý, bod 1 přeskočte.

## 1

Template repozitář již obsahuje aktualizované instrukce, které získáme buď:

- stáhnutím změn do svého repozitáře (ukážeme si příště)
- čerstvým naklonováním nového repozitáře z šablony [zde](https://github.com/czechitas/csharp3-template)
- nahlédnutím přímo do [souboru v Githubu](https://github.com/czechitas/csharp3-template/blob/main/ToDoList/01%20SettingUpProject.md).

Z instrukcí následujte první dvě sekce příkazů (`Creating ToDoList solution`, `Creating ToDoList.WebApi project`) a vytvořte si nový webový projekt. Přesunte se do složky projektu (e.g. `CSharp3/ToDoList/src/ToDoList.WebApi`) a spusťte jej pomocí příkazu `dotnet run`. V konzoli za odměnu dostanete adresu své první stránky.

## 2

V prohlížeči si vyzkoušejte, jak vaše stránka funguje pomocí developer tools (Ctrl + Shift + I nebo F12, případně pravým poklikem -> Inspect Element). Můžeme otestovat:

- Network tab, kde uvidíme requesty, jejich status a response. Co se stane, pokud zkusím jít na cestu, která neexistuje (například `/cesta`)?

## 3

Nakonec přidejte novou cestu `/nazdarSvete`, která vás pozdraví v češtině a otestujte si ji v prohlížeči.
