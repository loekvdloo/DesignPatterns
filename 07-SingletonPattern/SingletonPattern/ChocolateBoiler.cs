namespace SingletonPattern
{
    internal class ChocolateBoiler
    {
        // eager instantiation, wordt maar 1 keer aangemaakt dus ook goed met threads
        private static readonly ChocolateBoiler uniqueInstance = new ChocolateBoiler();

        private readonly object lockObject = new object();

        private bool empty;
        private bool boiled;

        public bool IsEmpty { get { return this.empty; } }
        public bool IsBoiled { get { return this.boiled; } }

        // This code is only started when the boiler is empty
        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChocolateBoiler GetInstance()
        {
            return uniqueInstance;
        }

        // To fill the boiler it must be empty and once it is full, we set the empty and boiled flag
        public void fill()
        {
            // lock zodat 2 threads niet tegelijk kunnen vullen
            lock (lockObject)
            {
                if (empty)
                {
                    empty = false;
                    boiled = false;
                }
            }
        }

        // To drain the boiler, it must be full (non empty) and also boiled.
        // Once it is drained we set empty back to true
        public void drain()
        {
            lock (lockObject)
            {
                if (!empty && boiled)
                {
                    empty = true;
                }
            }
        }

        // To boil the mixture, the boiler has to be full and not already boiled.
        // Once it is boiled we set the boiled flag to true
        public void boil()
        {
            lock (lockObject)
            {
                if (!empty && !boiled)
                {
                    boiled = true;
                }
            }
        }
    }
}
