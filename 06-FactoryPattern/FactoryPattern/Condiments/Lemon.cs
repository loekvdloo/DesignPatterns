namespace FactoryPattern
{
    public class Lemon : CondimentDecorator
    {
        public Lemon(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Lemon";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.10m;
        }
    }
}
