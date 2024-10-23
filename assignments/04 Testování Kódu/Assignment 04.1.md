# Assignment 04.1 - API testování

## Cíl: Pokrýt náš API controller testy

Záměrem domácího úkolu bude dokončit testovací pokrytí našeho API controlleru. Pro každou operaci z controlleru si vytvořte separátní testovací třídu (e.g. `GetTests`, `DeleteTests`) a pokryjte ji testy pro možné scénáře.

Například pro `Delete` můžeme otestovat, že item s existujícím ID správně odstraníme z "databáze" a item s neexistujícím ID nám vrátí chybu, ale nic neodstraní.
