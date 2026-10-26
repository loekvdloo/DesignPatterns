namespace FactoryPattern
{
    public class VanillaSugar : CondimentDecorator
    {
        public VanillaSugar(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Vanilla Sugar";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 0.20m;
        }
    }
}
