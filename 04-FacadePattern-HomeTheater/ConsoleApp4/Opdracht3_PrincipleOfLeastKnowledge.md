# Opdracht #3 – Principle of Least Knowledge

## Code 1

```csharp
public float getTemp()
{
    return station.getThermometer().getTemperature();
}
```

**Overtreedt het principe? Ja.**

`House` roept een methode aan op een object (`Thermometer`) dat het terugkrijgt van een andere methode (`station.getThermometer()`).
Dat object is geen component van `House`, geen parameter en niet in de methode aangemaakt. `House` is daardoor
gekoppeld aan twee classes (`WeatherStation` én `Thermometer`) in plaats van één. Beter: `station.getTemperature()`.

## Code 2

```csharp
public float getTemp()
{
    Thermometer thermometer = station.getThermometer();
    return GetTempHelper(thermometer);
}
public float GetTempHelper(Thermometer thermometer)
{
    return thermometer.getTemperature();
}
```

**Overtreedt het principe? Nee** (technisch gezien niet).

Elke methode houdt zich aan de regels: `getTemp()` roept alleen een methode aan op een component (`station`) en op
het object zelf (`GetTempHelper`), en `GetTempHelper()` roept alleen een methode aan op een parameter.
Kanttekening: het is eigenlijk een trucje. `House` kent `Thermometer` nog steeds, dus de koppeling is niet echt
verminderd. De nette oplossing blijft `station.getTemperature()`.
