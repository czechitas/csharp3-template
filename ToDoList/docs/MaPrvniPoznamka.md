# Vzdy zacni takhle nadpisem

Tady uz pis libovolne jak se ti zamane.

## Pouzivej podnadpisy

A odkazy napíšeš takto [Markdown CheatSheet](https://www.markdownguide.org/cheat-sheet/) (v hranatych zavorkach je jak se odkaz zobrazi, v kulatych samotny odkaz)

Odkazovat se můžeš i na jiné stránky takto [Markdown Lookup](markdown-lookup.md)

### Pouzivej obrazky a vystrizky

Obrazky muzes vkladat i z internetu pomoci `control + v` (jednoduche uvozovky používáme pro zvyrazneni kousku textu)
Vložené obrazky se ti pak ulozi do aktualni slozky (zde do /docs) :)
![alt text](image.png) (vykricnik znaci odkaz na obrazek, v hranatych je alternativni odkaz/popisek obrazku, v kulatych lokalni odkaz na cestu k obrázku)
Jedná se pak o lokální odkaz z tohoto souboru na relativní cestu obrázku (/image.png)
Pokud si chceš obrázky ukládat do extra složky (např. /images), relativní cesta by byla images/nazevobrazku.koncovkaobrazku

Pripadne muzes takhle naprimo pouzit adresu obrazku z internetu: ![MarkdownHereIcon](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png)

Tento text je normalne
**Tento text je tucne** `control + b`
*Tento text je kurzivou* `control + i`
***Lze i kombinovat*** `control + b` `control + i`

### Seznamy

Neserazene

- prvni
  - prvni prvni
  - prvni druhy
- druhy
- treti

Serazene

1. prvni
   1. prvni prvni
   2. prvni druhy
2. druhy
3. treti

### Blok kódu

Na bloky kódu používáme následující syntax

```c#
using System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ahojte!")
    }
}
```

```zde je treba rict o jaky jazyk se jedna, jinak neni podporovano zvyrazneni syntaxe
using System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ahojte!")
    }
}
```

### A toť vše

S tímto si snad vystačíš ;) Poud ti neco chybí, dej vědět, přidáme, popřípadě se mrkni na
[Markdown Lookup](markdown-lookup.md)
