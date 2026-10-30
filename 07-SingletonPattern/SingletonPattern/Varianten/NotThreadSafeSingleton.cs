namespace SingletonPattern.Varianten
{
    // De "klassieke" lazy Singleton uit de slides, ZONDER bescherming tegen threads.
    // Wordt alleen gebruikt om de race condition te laten zien.
    public sealed class NotThreadSafeSingleton
    {
        private static NotThreadSafeSingleton? uniqueInstance;
        private static int createdCount;

        public static int CreatedCount => createdCount;

        private NotThreadSafeSingleton()
        {
            Interlocked.Increment(ref createdCount);
            // Het aanmaken "duurt even" (zoals een echte boiler opstarten).
            // Hierdoor wordt de race condition goed zichtbaar.
            Thread.Sleep(50);
        }

        public static NotThreadSafeSingleton GetInstance()
        {
            if (uniqueInstance == null)
            {
                // Meerdere threads kunnen hier tegelijk zijn -> meerdere instanties
                uniqueInstance = new NotThreadSafeSingleton();
            }
            return uniqueInstance;
        }
    }
}
