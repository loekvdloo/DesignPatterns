namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChocolateBoiler boiler = ChocolateBoiler.GetInstance();
            ChocolateBoiler boiler2 = ChocolateBoiler.GetInstance();

            Console.WriteLine("Zelfde boiler: " + (boiler == boiler2));

            boiler.fill();
            Console.WriteLine("Na fill: empty=" + boiler.IsEmpty + " boiled=" + boiler.IsBoiled);
            boiler.boil();
            Console.WriteLine("Na boil: empty=" + boiler.IsEmpty + " boiled=" + boiler.IsBoiled);
            boiler.drain();
            Console.WriteLine("Na drain: empty=" + boiler.IsEmpty + " boiled=" + boiler.IsBoiled);

            // testen met threads
            Console.WriteLine();
            Console.WriteLine("Test met threads:");
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(() =>
                {
                    ChocolateBoiler b = ChocolateBoiler.GetInstance();
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " boiler: " + b.GetHashCode());
                });
                threads.Add(t);
                t.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }
    }
}
