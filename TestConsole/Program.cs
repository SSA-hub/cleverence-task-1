using MyServer;

namespace TestConsole;

public static class Program
{
    static void Main()
    // итерации цикла выполняются параллельно, поэтому по ним понять что-то несколько сложно,
    // однако, итоговое значение всегда получается верным
    {
        Parallel.For(0, 100, i =>
        {
            if (i % 10 == 0) 
                Server.AddToCount(2);
            else
                Console.WriteLine("Iteration: {0}; Count: {1}", i, Server.GetCount());
        });
        Console.WriteLine(Server.GetCount());
        Console.WriteLine("Done.");
    }
}