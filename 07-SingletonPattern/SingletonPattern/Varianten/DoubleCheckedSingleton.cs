namespace SingletonPattern.Varianten
{
    // Oplossing 3: Double checked locking (slide 16)
    public sealed class DoubleCheckedSingleton
    {
        // volatile: elke thread leest altijd de nieuwste waarde en ziet nooit
        // een half aangemaakt object.
        private static volatile DoubleCheckedSingleton? uniqueInstance;

        // Let op: op de slide staat lock(uniqueInstance). Dat werkt niet, want
        // uniqueInstance is op dat moment nog null -> ArgumentNullException.
        // Daarom een apart object om op te locken.
        private static readonly object padlock = new object();

        private static int createdCount;

        public static int CreatedCount => createdCount;

        private DoubleCheckedSingleton()
        {
            Interlocked.Increment(ref createdCount);
            Thread.Sleep(50);
        }

        public static DoubleCheckedSingleton GetInstance()
        {
            if (uniqueInstance == null)          // 1e check: zonder lock (snel)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)  // 2e check: binnen de lock (veilig)
                    {
                        uniqueInstance = new DoubleCheckedSingleton();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
