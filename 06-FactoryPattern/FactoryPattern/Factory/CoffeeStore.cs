namespace FactoryPattern
{
    // Creator: de procedure voor een bestelling ligt hier vast,
    // welke drank er gemaakt wordt beslist de subclass (factory method).
    public abstract class CoffeeStore
    {
        public Beverage OrderCoffee(CoffeeType type)
        {
            Beverage beverage = CreateCoffee(type);

            Console.WriteLine($"Bestelling : {type.GetMenuName()}");
            Console.WriteLine($"Bereiden   : {beverage.GetDescription()}");
            Console.WriteLine($"Prijs      : {beverage.Cost():C}");
            Console.WriteLine();

            return beverage;
        }

        // De factory method
        protected abstract Beverage CreateCoffee(CoffeeType type);
    }
}
