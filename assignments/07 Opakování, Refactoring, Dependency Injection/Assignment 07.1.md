# Assignment 07.1

## Cíl

Prověřit si znalost psaní izolovaných testů a práce s mocky. Celkové otestování našeho controlleru.

## Zadání

Vytvořte následující unit testy testující třídu `ToDoItemsController` s pomocí mockování (využití knihovny NSubstitute)

Nějaké ty testy již jistě máte vytvořené, některé jsem dal do šablony, něco jsme procvičovali v lekci, něco v breakout roomech. Pokud jste minule udělaly nepovinný úkol, máte vyhráno.

Pojďme si dokončit všechny testy tak, abychom měli náš `ToDoItemsController` řádně otestovaný pro práci na frontendu.

Pokud už máte testy napsané, přejmenujte prosím vaše stávající na zmíněné níže, tak aby odpovídaly tomu, co dělají. Nezapomeňte využívat kontrolu volání metod mocku pomocí .Received()

Ať se moc daří ;)
PS.: Pokud by byly nějaké nejasnosti, co by měl který test testovat, hned napište na Discord -> #otazky

## ToDoList.Test Unit Tests

### CREATE

Post_CreateValidRequest_ReturnsCreatedAtAction()
Post_CreateUnhandledException_ReturnsInternalServerError()

### READ

Get_ReadWhenSomeItemAvailable_ReturnsOk()
Get_ReadWhenNoItemAvailable_ReturnsNotFound()
Get_ReadUnhandledException_ReturnsInternalServerError()

### READBYID

Get_ReadByIdWhenSomeItemAvailable_ReturnsOk()
Get_ReadByIdWhenItemIsNull_ReturnsNotFound()
Get_ReadByIdUnhandledException_ReturnsInternalServerError()

### UPDATEBYID

Put_UpdateByIdWhenItemUpdated_ReturnsNoContent()
Put_UpdateByIdWhenIdNotFound_ReturnsNotFound()
Put_UpdateByIdUnhandledException_ReturnsInternalServerError()

### DELETEBYID

Delete_DeleteByIdValidItemId_ReturnsNoContent()
Delete_DeleteByIdInvalidItemId_ReturnsNotFound()

Delete_DeleteByIdUnhandledException_ReturnsInternalServerError()
(pokud používáte repository.ReadById() následované repository.UpdateById(), je potřeba vytvořit dva testy, jeden za každou metodu, kterou namockujeme tak, aby vyhazovala výjimku)

## Extra (nepovinné)

Projděte si dokumentaci knihovny [FluentAssertions](https://fluentassertions.com/basicassertions/)
"nakupte" si její nuget (najdete jako první věc když vyhledáte `FluentAssertions`) a přepište si assert části testů s pomocí této knihovny. (nemusíte všechny, jde o to si tuto knihovnu vyzkoušet)

Ukázka "fluent" assertions najdete zde [FluentAssertionsExamples](https://fluentassertions.com/tips/#mstest-migration). Jedná se o Asserty z MSTest, ale vypadají dosti podobně jako v nám používaném testovacím frameworku xUnit.

Dejte nám vědět, jak se vám s takovýmito "fluent" asserty pracovalo.
