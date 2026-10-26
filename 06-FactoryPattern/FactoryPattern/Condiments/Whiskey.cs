namespace FactoryPattern
{
    public class Whiskey : CondimentDecorator
    {
        public Whiskey(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whiskey";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 2.00m;
        }
    }
}
