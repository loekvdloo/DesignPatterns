using System.Runtime.CompilerServices;

namespace SingletonPattern.Varianten
{
    // Oplossing 1: Synchronize the GetInstance() method (slide 14)
    // Er kan maar één thread tegelijk in GetInstance() zijn.
    public sealed class SynchronizedSingleton
    {
        private static SynchronizedSingleton? uniqueInstance;
        private static int createdCount;

        public static int CreatedCount => createdCount;

        private SynchronizedSingleton()
        {
            Interlocked.Increment(ref createdCount);
            Thread.Sleep(50);
        }

        // Bij een static method lockt dit attribuut op typeof(SynchronizedSingleton).
        // Nadeel: ELKE aanroep wacht op de lock, ook als de instantie al lang bestaat.
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static SynchronizedSingleton GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new SynchronizedSingleton();
            }
            return uniqueInstance;
        }
    }
}
