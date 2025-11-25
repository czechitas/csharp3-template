# Assignment FinalProject.2 - Frontend

## Cíl

Samostatné dokončení nové funkcionality rozšířením frontendu

## Zadání

S hotovým backendem už nám stačí naši kategorii jen přidat na frontend :) Stejně jako na backendu i zde ji budeme reprezentovat pomocí nullable stringu. To bude vyžadovat alespoň následující změny:

- Rozšíříme relevatní DTOs a Views
- `ToDoItemsClient` umí přijímat a odesílat `Category` na backend
- Tabulka v komponentě `Dashboard` obsahuje sloupec `Category`
- Formulář v komponentě `EditToDoItem` obsahuje input `Category`, který ukládá novou hodnotu na backend

Na závěr proveďte E2E (end-to-end) testování na kontrolu, zda se kategorie správně zobrazují a ukládají od uživatelského rozhraní až po databázi.
