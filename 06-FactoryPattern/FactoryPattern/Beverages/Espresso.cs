namespace FactoryPattern
{
    // Basis-drank
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override decimal Cost()
        {
            return 1.99m;
        }
    }
}
