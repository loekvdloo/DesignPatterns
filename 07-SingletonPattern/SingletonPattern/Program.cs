using System.Diagnostics;
using SingletonPattern;
using SingletonPattern.Varianten;

// ===================== Opdracht 2 – Implementing =====================
Console.WriteLine("=== Opdracht 2: ChocolateBoiler als Singleton ===");

// new ChocolateBoiler();  // <- compileert niet meer: de constructor is private

ChocolateBoiler boiler = ChocolateBoiler.GetInstance();
ChocolateBoiler boiler2 = ChocolateBoiler.GetInstance();
Console.WriteLine($"boiler en boiler2 zijn hetzelfde object: {ReferenceEquals(boiler, boiler2)}");

PrintState("Start", boiler);
boiler.fill();
PrintState("Na fill()", boiler);
boiler.boil();
PrintState("Na boil()", boiler);
boiler.drain();
PrintState("Na drain()", boiler);

// ===================== Opdracht 3 – Thread safe =====================
Console.WriteLine();
Console.WriteLine("=== Opdracht 3: 20 threads roepen tegelijk GetInstance() aan ===");

const int threadCount = 20;
Report("Zonder bescherming", CountInstances(NotThreadSafeSingleton.GetInstance, threadCount), NotThreadSafeSingleton.CreatedCount);
Report("Synchronized method", CountInstances(SynchronizedSingleton.GetInstance, threadCount), SynchronizedSingleton.CreatedCount);
Report("Eager instantiation", CountInstances(EagerSingleton.GetInstance, threadCount), EagerSingleton.CreatedCount);
Report("Double checked locking", CountInstances(DoubleCheckedSingleton.GetInstance, threadCount), DoubleCheckedSingleton.CreatedCount);
Report("ChocolateBoiler (eager)", CountInstances(ChocolateBoiler.GetInstance, threadCount), null);

// Ook de toestand van de boiler is beschermd: 20 threads doen tegelijk fill/boil/drain.
var workers = Enumerable.Range(0, threadCount).Select(_ => new Thread(() =>
{
    for (int i = 0; i < 10_000; i++)
    {
        ChocolateBoiler b = ChocolateBoiler.GetInstance();
        b.fill();
        b.boil();
        b.drain();
    }
})).ToList();
workers.ForEach(t => t.Start());
workers.ForEach(t => t.Join());
PrintState("Na 200.000 fill/boil/drain-rondes uit 20 threads", ChocolateBoiler.GetInstance());

// ===================== Performance =====================
Console.WriteLine();
Console.WriteLine("=== Performance: 20 threads x 1.000.000 keer GetInstance() ===");
Console.WriteLine("(de instanties bestaan al, dus dit meet alleen de kosten van GetInstance zelf)");
Measure("Synchronized method", () => SynchronizedSingleton.GetInstance());
Measure("Eager instantiation", () => EagerSingleton.GetInstance());
Measure("Double checked locking", () => DoubleCheckedSingleton.GetInstance());


// ===================== Hulpmethodes =====================
static void PrintState(string label, ChocolateBoiler b)
{
    Console.WriteLine($"{label,-50} IsEmpty = {b.IsEmpty,-5}  IsBoiled = {b.IsBoiled}");
}

// Start alle threads op precies hetzelfde moment (Barrier) en telt hoeveel
// verschillende objecten er uit GetInstance() zijn gekomen.
static int CountInstances(Func<object> getInstance, int threads)
{
    var results = new object[threads];
    using var startSignal = new Barrier(threads);

    var list = new List<Thread>();
    for (int i = 0; i < threads; i++)
    {
        int index = i;
        list.Add(new Thread(() =>
        {
            startSignal.SignalAndWait();
            results[index] = getInstance();
        }));
    }
    list.ForEach(t => t.Start());
    list.ForEach(t => t.Join());

    return results.Distinct(ReferenceEqualityComparer.Instance).Count();
}

static void Report(string name, int distinct, int? created)
{
    string createdText = created.HasValue ? $", constructor {created} keer uitgevoerd" : "";
    string verdict = distinct == 1 ? "OK" : "FOUT";
    Console.WriteLine($"{name,-26} -> {distinct} verschillende instantie(s){createdText}  [{verdict}]");
}

static void Measure(string name, Action call)
{
    const int threads = 20;
    const int callsPerThread = 1_000_000;

    var list = Enumerable.Range(0, threads).Select(_ => new Thread(() =>
    {
        for (int i = 0; i < callsPerThread; i++)
        {
            call();
        }
    })).ToList();

    var sw = Stopwatch.StartNew();
    list.ForEach(t => t.Start());
    list.ForEach(t => t.Join());
    sw.Stop();

    Console.WriteLine($"{name,-26} {sw.ElapsedMilliseconds,6} ms");
}
