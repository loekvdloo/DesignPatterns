namespace FactoryPattern
{
    // Abstract product: alles wat de factory maakt is een Beverage
    public abstract class Beverage
    {
        protected string description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return description;
        }

        public abstract decimal Cost();
    }
}
