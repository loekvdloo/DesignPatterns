using System.Globalization;

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("nl-NL");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // De barista werkt alleen met de store en de enum.
            // Hij kan dus alleen dranken bestellen die op de kaart staan.
            CoffeeStore store = new StarbuzzCoffeeStore();

            Console.WriteLine("===== Een paar bestellingen =====");
            store.OrderCoffee(CoffeeType.Cappuccino);
            store.OrderCoffee(CoffeeType.Mocha);
            store.OrderCoffee(CoffeeType.IrishCoffee);

            // Zonder factory kon dit: water met 15x slagroom. Dat staat niet op de kaart,
            // en via store.OrderCoffee(...) is het niet meer te bestellen.

            Console.WriteLine("===== De hele kaart =====");
            foreach (CoffeeType type in Enum.GetValues<CoffeeType>())
            {
                store.OrderCoffee(type);
            }

            Console.ReadLine();
        }
    }
}
