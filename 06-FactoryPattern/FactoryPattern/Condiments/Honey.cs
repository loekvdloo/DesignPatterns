namespace FactoryPattern
{
    public class Honey : CondimentDecorator
    {
        public Honey(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Honey";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.25m;
        }
    }
}
