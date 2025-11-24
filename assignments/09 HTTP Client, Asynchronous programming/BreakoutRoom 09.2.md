# BreakoutRoom 09.2

## Vyjasnění zadání závěrečného projektu

**Cíl:** Procvičit komunikaci mezi zadavatelem (kouč/zákazník) a vývojářem (účastnice). Naučit se správně specifikovat požadavky a ptát se na nejasnosti.

**Kouč hraje roli:** Zákazníka/Sales zastupitele, která má konkrétní požadavky

**Účastnice hrají roli:** Vývojářů, kteří mají tyto požadavky naimplementovat

### Intro

Přišel vám e-mail od vašeho Sales týmu s následující zprávou:

> "Ahoj,
>
> Potřebujeme, aby se v aplikaci ToDoList mohl každý úkol kategorizovat. Když se zákazník podívá na seznam úkolů, rád by viděl možnost úkoly kategorizovat.
>
> Rádi bychom měli v aplikaci plnou podporu kategorizace úkolů. No a když už budeme mít ty kategorie, můžeme podpořit i nějaké jejich filtrování nebo třízení?
>
> Rádi bychom viděli tuto funkcionalitu hotovou do 3 týdnů.
>
> Děkujeme,
> Tým Produktu (Sales)
>
> PS. Už jsme tuto feature zákazníkovi slíbili, deadline se nedá posunout, sorry..."

### Co mají účastnice dělat

**Cíl:** Vyjasniť si od kouče (zákazníka) podrobnosti, abyste mohli dát přesný odhad a vytvořit konkrétní plán implementace.

**Nápady na co se zeptat pro účastnice:**

- Datový model: Jaký formát bude mít kategorie? (string? select box s předchozíma možnostma? nové entity?)
- Frontend: Kde všude se kategorie budou zobrazovat/editovat?
- Backend: Jak se budou kategorie ukládat do databáze?
- Filtrování/Řazení: Je to povinné nebo optional?
- Výkon: Kolik se jich bude očekávat? (ovlivňuje DB design)
- Timeline: Je 3 týdny reálný odhad? (nelze ovlivnit)

**Pozn.:** Kouč (zákazník) bude odpovídat, ale někdy si nemusí být něčím jist. Vaše práce je pracovat s nejasnostmi a dojít k dohodě. 🤝

### Instrukce pro kouče

Hrajete roli zákazníka/skušeného kolegy. Odpovídáte na otázky vývojářů, ale:

- **Nevíte vždy všechno:** Pokud se vás na něco zeptají, co jste si neuvědomili, říkejte: *"Dobrá otázka, o tom jsem nepřemýšlel/a. Co by bylo nejjednodušší/nejlevnější/nejrychlejší?"*
- **Máte rozpočet:** cca 10 hodin práce
- **Máte deadline:** Za 3 týdny musí být hotovo
- **Upřesňujte:** Pokud se vývojáři zeptají dobrou otázkou, oceňte ji a odpovězte
- **Zachovejte jednoduchost zadání:** Cílem je si vyjasnit zadání, ne jej zkomplikovat. Nemusíte pokrýt všechny "edge-case".

## Výstup

Na konci hry byste měli mít:

**Upřesněné požadavky** (co se má dělat)
**Jasný plan** (jak se to bude dělat)
**Realistický odhad** (co se stihne - 3 týdny max)
**Komunikační zkušenost** (jak se bavit se zadavatelem)
