namespace FactoryPattern
{
    // Decorator: IS-A Beverage en HAS-A Beverage
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;

        protected CondimentDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public abstract override string GetDescription();
    }
}
