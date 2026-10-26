namespace FactoryPattern
{
    public class IceCream : CondimentDecorator
    {
        public IceCream(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Ice cream";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 1.00m;
        }
    }
}
