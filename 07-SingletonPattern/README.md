# Singleton Pattern – Chocolate Boiler

Uitwerking van *API 3 – 006 – Singleton Pattern*. Het ingevulde Word-document staat in deze map.

## Opdracht 1 – Setting up

Het project uit `SingletonPattern.zip` staat in [`SingletonPattern/`](SingletonPattern/). Net als de andere projecten in deze repo draait het op .NET 8 (in de zip stond nog .NET 6).

## Opdracht 2 – Implementing

De `ChocolateBoiler` is een Singleton gemaakt in de drie stappen van slide 8:

1. **private constructor**: niemand kan meer `new ChocolateBoiler()` doen.
2. **private static variabele** `uniqueInstance` die de enige instantie bevat.
3. **static method** `GetInstance()` die die instantie teruggeeft.

```csharp
public sealed class ChocolateBoiler
{
    private static readonly ChocolateBoiler uniqueInstance = new ChocolateBoiler();

    private ChocolateBoiler()
    {
        empty = true;
        boiled = false;
    }

    public static ChocolateBoiler GetInstance()
    {
        return uniqueInstance;
    }
    ...
}
```

Gebruik:

```csharp
ChocolateBoiler boiler = ChocolateBoiler.GetInstance();
boiler.fill();
boiler.boil();
boiler.drain();
```

Code: [`SingletonPattern/ChocolateBoiler.cs`](SingletonPattern/ChocolateBoiler.cs)

## Opdracht 3 – Thread safe

### Het probleem

Met de "gewone" lazy Singleton (`if (uniqueInstance == null) uniqueInstance = new ...`) kunnen twee threads tegelijk de `if` doorkomen. Ze zien allebei `null` en maken allebei een boiler aan. Dan zijn er twee boilers, en precies dat moet de Singleton voorkomen. [`Varianten/NotThreadSafeSingleton.cs`](SingletonPattern/Varianten/NotThreadSafeSingleton.cs) laat dit zien: `Program.cs` start 20 threads tegelijk en telt hoeveel verschillende instanties eruit komen.

### De drie oplossingen

Elke oplossing staat als losse class in [`SingletonPattern/Varianten/`](SingletonPattern/Varianten/), zodat `Program.cs` ze naast elkaar kan testen (aantal instanties en snelheid).

| Solution to multi-threading problem | Omschrijving van toepasbaarheid |
|---|---|
| **Synchronize the GetInstance() method** | Met `[MethodImpl(MethodImplOptions.Synchronized)]` kan maar één thread tegelijk in `GetInstance()`. Het werkt altijd en het is maar één regel extra, dus makkelijk te begrijpen. **Performance:** de lock is alleen nodig bij de allereerste aanroep, maar elke aanroep moet erop wachten. Als veel threads vaak `GetInstance()` aanroepen, staan ze in de rij en wordt het programma trager. **Maintainability:** het attribuut lockt bij een static method op `typeof(ChocolateBoiler)`. Andere code kan op hetzelfde object locken, wat tot deadlocks kan leiden. Dat zie je niet aan de code, dus het is lastig te onderhouden. **Toepasbaar** als `GetInstance()` weinig wordt aangeroepen en performance niet belangrijk is. |
| **Eager instantiation** | De instantie wordt direct aangemaakt in een `static readonly` veld. De CLR voert die initializer precies één keer uit en zorgt zelf dat dat thread-safe gebeurt. **Performance:** `GetInstance()` geeft alleen de instantie terug, zonder `if` en zonder lock. Dit is de snelste oplossing. **Maintainability:** het is de minste en simpelste code, je kunt er weinig fout aan doen. **Nadelen:** het object wordt altijd gemaakt, ook als het nooit gebruikt wordt. Dat is een probleem als de constructor zwaar is (veel geheugen, database, bestanden) of als hij gegevens nodig heeft die pas later bekend zijn. Gaat er iets mis in de constructor, dan krijg je een `TypeInitializationException`, en die is lastiger te debuggen. **Toepasbaar** als het object goedkoop is om te maken en het programma het toch altijd nodig heeft. |
| **Double Checked locking** | Eerst een check zonder lock. Alleen als de instantie nog niet bestaat, wordt er gelockt en nog een keer gecheckt. **Performance:** de lock wordt alleen bij de eerste aanroep(en) gebruikt, daarna is het bijna net zo snel als eager. De instantie wordt pas gemaakt als hij echt nodig is (lazy). **Maintainability:** dit is de moeilijkste code en het gaat snel fout. Vergeet je `volatile`, dan kan een thread een half aangemaakt object zien. De code op slide 16 doet `lock(uniqueInstance)`, maar `uniqueInstance` is dan nog `null`, en dat geeft een `ArgumentNullException`. Je moet op een apart object locken (`padlock`). **Toepasbaar** als het object zwaar is om aan te maken én `GetInstance()` vaak wordt aangeroepen. In C# kun je daarvoor ook `Lazy<T>` gebruiken. Dat doet hetzelfde, maar dan hoef je de lock niet zelf te schrijven. |

### Mijn keuze voor de ChocolateBoiler: eager instantiation

- De boiler is goedkoop om te maken (twee booleans) en de fabriek heeft hem altijd nodig. Het nadeel van eager (object wordt altijd gemaakt) speelt hier dus geen rol.
- Het is de snelste oplossing en ook de simpelste code, dus het beste voor performance én maintainability.
- Synchronized is onnodig traag, en double checked locking is meer code en meer kans op fouten, terwijl lazy aanmaken hier niets oplevert.

### Extra: ook de toestand van de boiler is thread-safe

Een Singleton zorgt er alleen voor dat er één boiler is. Twee threads kunnen nog steeds tegelijk `fill()` aanroepen, allebei `empty == true` zien en allebei vullen, zodat de boiler overloopt. Daarom gebeurt in `fill()`, `boil()` en `drain()` de check en de wijziging samen binnen een `lock (stateLock)`.

## Uitvoeren

Start het project `SingletonPattern`. `Program.cs` doet:

1. **Opdracht 2**: twee keer `GetInstance()` en laat zien dat het hetzelfde object is, daarna fill → boil → drain.
2. **Opdracht 3**: 20 threads roepen precies tegelijk `GetInstance()` aan, voor elke variant. Zonder bescherming komen er meerdere instanties uit (`FOUT`), bij de drie oplossingen precies één (`OK`).
3. **Performance**: 20 threads × 1.000.000 aanroepen van `GetInstance()` per variant. De synchronized-variant is duidelijk het traagst, omdat elke aanroep op de lock moet wachten. De exacte tijden hangen af van de computer.
