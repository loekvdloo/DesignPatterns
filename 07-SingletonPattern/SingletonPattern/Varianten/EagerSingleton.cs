namespace SingletonPattern.Varianten
{
    // Oplossing 2: Eager instantiation (slide 15)
    // Dit is dezelfde aanpak als in ChocolateBoiler.cs, maar los zodat hij in de
    // vergelijking (Program.cs) naast de andere varianten kan staan.
    public sealed class EagerSingleton
    {
        private static int createdCount;
        private static readonly EagerSingleton uniqueInstance = new EagerSingleton();

        public static int CreatedCount => createdCount;

        static EagerSingleton()
        {
        }

        private EagerSingleton()
        {
            Interlocked.Increment(ref createdCount);
            Thread.Sleep(50);
        }

        // Geen if, geen lock: alleen de instantie teruggeven.
        public static EagerSingleton GetInstance()
        {
            return uniqueInstance;
        }
    }
}
