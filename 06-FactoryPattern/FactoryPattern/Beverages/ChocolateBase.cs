namespace FactoryPattern
{
    // Basis-drank voor Chocolate milk
    public class ChocolateBase : Beverage
    {
        public ChocolateBase()
        {
            description = "Chocolate";
        }

        public override decimal Cost()
        {
            return 1.50m;
        }
    }
}
