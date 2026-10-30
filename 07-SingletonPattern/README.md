# Singleton Pattern

Opdracht 006 Singleton Pattern. Het ingevulde Word document staat ook in deze map.

## Opdracht 2

ChocolateBoiler is nu een Singleton:
- de constructor is private
- er is een private static variabele `uniqueInstance`
- met `GetInstance()` krijg je altijd dezelfde boiler

```csharp
ChocolateBoiler boiler = ChocolateBoiler.GetInstance();
```

## Opdracht 3

| Oplossing | Toepasbaarheid |
|---|---|
| Synchronize GetInstance() | Werkt wel, maar elke keer dat GetInstance() wordt aangeroepen moet er gewacht worden op de lock, ook als de boiler al bestaat. Dat is slecht voor de performance als het vaak wordt aangeroepen. Wel makkelijk want het is maar 1 regel extra. |
| Eager instantiation | De instantie wordt meteen aangemaakt als de class geladen wordt, C# zorgt dat dit maar 1 keer gebeurt. Snelste oplossing en weinig code dus goed te onderhouden. Nadeel is dat het object altijd gemaakt wordt ook als je het niet gebruikt. |
| Double checked locking | Er wordt alleen gelockt als de instantie nog null is, dus daarna is het snel. Maar de code is ingewikkelder en je kan makkelijk iets vergeten (bijvoorbeeld volatile), dat is slechter voor maintainability. Handig als het object zwaar is om te maken. |

Ik heb gekozen voor eager instantiation omdat de ChocolateBoiler toch altijd nodig is en niet zwaar is om te maken. Ook heb ik een lock in fill, boil en drain gezet zodat 2 threads niet tegelijk de boiler kunnen vullen.
