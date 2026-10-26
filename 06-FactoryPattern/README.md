# Factory Method Pattern – Starbuzz

Uitwerking van *API 3 – 005 – Abstract Factory Method Pattern*.

## Opdracht 1 – Setting up

Dit project is een kopie van het Decorator-project (`05-DecoratorPattern`), hernoemd naar **FactoryPattern**. De opdracht bouwt voort op de Starbuzz-koffie (slide 58). Daarom zijn de notificatie-decorators vervangen door koffie-decorators: een basisdrank met condiments eromheen.

## Opdracht 2 – Realiseer

Een barista mag alleen dranken van de kaart bestellen. Zonder factory kon iedereen zelf decorators stapelen, bijvoorbeeld water met 15× slagroom. Nu loopt elke bestelling via een **factory method** met een **enum** als argument.

```csharp
CoffeeStore store = new StarbuzzCoffeeStore();
store.OrderCoffee(CoffeeType.Cappuccino);
```

| Rol in het pattern | Class |
|---|---|
| Creator (abstract) | `CoffeeStore`: `OrderCoffee()` ligt vast, `CreateCoffee()` is de abstracte factory method |
| Concrete creator | `StarbuzzCoffeeStore`: de enige class die weet hoe elke drank wordt opgebouwd |
| Product (abstract) | `Beverage` |
| Concrete producten | `Espresso`, `ChocolateBase` en de condiment-decorators in `Condiments/` |
| Argument | `CoffeeType` (enum met de 29 dranken van de kaart) |

Omdat `CoffeeType` alleen de dranken van de kaart bevat, kan de barista niets anders bestellen. Een waarde die niet in de enum staat, geeft een `ArgumentOutOfRangeException`.

### Voorbeelduitvoer

```
Bestelling : Cappuccino
Bereiden   : Espresso, Steamed Milk, Milk Foam
Prijs      : € 2,44

Bestelling : Mocha
Bereiden   : Espresso, Chocolate, Steamed Milk, Whip
Prijs      : € 2,54

Bestelling : Irish Coffee
Bereiden   : Espresso, Espresso, Whiskey, Whip
Prijs      : € 4,69
```

De prijzen staan niet in de opdracht. Ze zijn zelf gekozen, en voor Espresso, Whip en Milk zijn ze gebaseerd op het Starbuzz-voorbeeld.
