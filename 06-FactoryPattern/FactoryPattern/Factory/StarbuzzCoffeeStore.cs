namespace FactoryPattern
{
    // Concrete creator: de enige plek die weet hoe je de dranken
    // van de kaart opbouwt uit een basis en condiment-decorators.
    public class StarbuzzCoffeeStore : CoffeeStore
    {
        protected override Beverage CreateCoffee(CoffeeType type)
        {
            return type switch
            {
                CoffeeType.Espresso => new Espresso(),
                CoffeeType.Doppio => new ExtraEspresso(new Espresso()),
                CoffeeType.Lungo => new Water(new Espresso()),
                CoffeeType.Macchiato => new MilkFoam(new Espresso()),
                CoffeeType.Corretta => new Liqueur(new Espresso()),
                CoffeeType.ConPanna => new Whip(new Espresso()),
                CoffeeType.Cappuccino => new MilkFoam(new SteamedMilk(new Espresso())),
                CoffeeType.Americano => new Water(new Water(new Espresso())),
                CoffeeType.CaffeLatte => new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso()))),
                CoffeeType.FlatWhite => new SteamedMilk(new SteamedMilk(new Espresso())),
                CoffeeType.Romana => new Lemon(new Espresso()),
                CoffeeType.Morocchino => new MilkFoam(new Chocolate(new Espresso())),
                CoffeeType.Mocha => new Whip(new SteamedMilk(new Chocolate(new Espresso()))),
                CoffeeType.Bicerin => new Whip(new WhiteChocolate(new BlackChocolate(new Espresso()))),
                CoffeeType.Breve => new HalfMilk(new MilkFoam(new Espresso())),
                CoffeeType.RafCoffee => new Cream(new VanillaSugar(new Espresso())),
                CoffeeType.MeadRaf => new Cream(new Honey(new Espresso())),
                CoffeeType.Galao => new MilkFoam(new MilkFoam(new Espresso())),
                CoffeeType.CaffeAffogato => new IceCream(new ExtraEspresso(new Espresso())),
                CoffeeType.ViennaCoffee => new Whip(new Whip(new ExtraEspresso(new Espresso()))),
                CoffeeType.Glace => new IceCream(new Espresso()),
                CoffeeType.ChocolateMilk => new Milk(new Milk(new ChocolateBase())),
                CoffeeType.DemiCreme => new Cream(new Cream(new ExtraEspresso(new Espresso()))),
                CoffeeType.LatteMacchiato => new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso()))),
                CoffeeType.Freddo => new Ice(new Liqueur(new Espresso())),
                CoffeeType.Frappuccino => new Whip(new SteamedMilk(new Ice(new Espresso()))),
                CoffeeType.CaramelFrappuccino => new Syrup(new Cream(new SteamedMilk(new Ice(new Espresso())))),
                CoffeeType.Frappe => new IceCream(new SteamedMilk(new SteamedMilk(new Espresso()))),
                CoffeeType.IrishCoffee => new Whip(new Whiskey(new ExtraEspresso(new Espresso()))),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Deze drank staat niet op de kaart.")
            };
        }
    }
}
