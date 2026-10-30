namespace SingletonPattern
{
    // Opdracht 2 + 3: de ChocolateBoiler als thread-safe Singleton.
    //
    // Gekozen oplossing: eager instantiation.
    // De CLR voert een static field initializer precies één keer uit en zorgt er zelf voor
    // dat dat thread-safe gebeurt. Daardoor is er geen lock nodig in GetInstance().
    public sealed class ChocolateBoiler
    {
        // 2) private static variabele die de ENIGE instantie bevat
        private static readonly ChocolateBoiler uniqueInstance = new ChocolateBoiler();

        // Lock voor de toestand van de boiler (zie uitleg bij fill/drain/boil)
        private readonly object stateLock = new object();

        private bool empty;
        private bool boiled;

        public bool IsEmpty { get { lock (stateLock) { return empty; } } }
        public bool IsBoiled { get { lock (stateLock) { return boiled; } } }

        // Een expliciete static constructor zorgt ervoor dat C# de instantie pas aanmaakt
        // als de class voor het eerst gebruikt wordt (en niet "ergens eerder").
        static ChocolateBoiler()
        {
        }

        // 1) private constructor: niemand buiten deze class kan "new ChocolateBoiler()" doen.
        // This code is only started when the boiler is empty
        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        // 3) static method die de enige instantie teruggeeft (global point of access)
        public static ChocolateBoiler GetInstance()
        {
            return uniqueInstance;
        }

        // Singleton zorgt alleen dat er één boiler is. Twee threads kunnen nog steeds
        // tegelijk fill() aanroepen en allebei "empty == true" zien -> de boiler loopt over.
        // Daarom wordt elke check + wijziging van de toestand binnen één lock gedaan.

        // To fill the boiler it must be empty and once it is full, we set the empty and boiled flag
        public void fill()
        {
            lock (stateLock)
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
            lock (stateLock)
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
            lock (stateLock)
            {
                if (!empty && !boiled)
                {
                    boiled = true;
                }
            }
        }
    }
}
