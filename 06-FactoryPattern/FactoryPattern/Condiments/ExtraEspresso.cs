namespace FactoryPattern
{
    public class ExtraEspresso : CondimentDecorator
    {
        public ExtraEspresso(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Espresso";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.60m;
        }
    }
}
