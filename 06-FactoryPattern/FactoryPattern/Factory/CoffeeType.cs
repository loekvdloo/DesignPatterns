namespace FactoryPattern
{
    // Het argument voor de factory method: alleen deze dranken staan op de kaart
    public enum CoffeeType
    {
        Espresso,
        Doppio,
        Lungo,
        Macchiato,
        Corretta,
        ConPanna,
        Cappuccino,
        Americano,
        CaffeLatte,
        FlatWhite,
        Romana,
        Morocchino,
        Mocha,
        Bicerin,
        Breve,
        RafCoffee,
        MeadRaf,
        Galao,
        CaffeAffogato,
        ViennaCoffee,
        Glace,
        ChocolateMilk,
        DemiCreme,
        LatteMacchiato,
        Freddo,
        Frappuccino,
        CaramelFrappuccino,
        Frappe,
        IrishCoffee
    }

    public static class CoffeeTypeExtensions
    {
        // Naam zoals hij op de kaart staat
        public static string GetMenuName(this CoffeeType type)
        {
            return type switch
            {
                CoffeeType.ConPanna => "Con Panna",
                CoffeeType.CaffeLatte => "Caffè Latte",
                CoffeeType.FlatWhite => "Flat White",
                CoffeeType.RafCoffee => "Raf coffee",
                CoffeeType.MeadRaf => "Mead raf",
                CoffeeType.CaffeAffogato => "Caffè affogato",
                CoffeeType.ViennaCoffee => "Vienna coffee",
                CoffeeType.ChocolateMilk => "Chocolate milk",
                CoffeeType.DemiCreme => "Demi-crème",
                CoffeeType.LatteMacchiato => "Latte macchiato",
                CoffeeType.CaramelFrappuccino => "Caramel frappuccino",
                CoffeeType.IrishCoffee => "Irish Coffee",
                _ => type.ToString()
            };
        }
    }
}
