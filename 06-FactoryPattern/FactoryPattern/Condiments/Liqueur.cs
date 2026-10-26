namespace FactoryPattern
{
    public class Liqueur : CondimentDecorator
    {
        public Liqueur(Beverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Liqueur";
        }

        public override decimal Cost()
        {
            return beverage.Cost() + 1.50m;
        }
    }
}
