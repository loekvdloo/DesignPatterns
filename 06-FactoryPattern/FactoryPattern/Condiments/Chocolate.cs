namespace FactoryPattern
{
    public class Chocolate : CondimentDecorator
    {
        public Chocolate(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Chocolate";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.20m;
        }
    }
}
