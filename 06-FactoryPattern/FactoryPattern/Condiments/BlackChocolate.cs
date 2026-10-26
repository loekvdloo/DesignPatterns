namespace FactoryPattern
{
    public class BlackChocolate : CondimentDecorator
    {
        public BlackChocolate(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Black Chocolate";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.25m;
        }
    }
}
