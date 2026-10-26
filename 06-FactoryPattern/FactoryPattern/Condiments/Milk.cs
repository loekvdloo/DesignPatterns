namespace FactoryPattern
{
    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Milk";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.10m;
        }
    }
}
