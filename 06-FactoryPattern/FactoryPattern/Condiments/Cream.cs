namespace FactoryPattern
{
    public class Cream : CondimentDecorator
    {
        public Cream(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Cream";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.25m;
        }
    }
}
