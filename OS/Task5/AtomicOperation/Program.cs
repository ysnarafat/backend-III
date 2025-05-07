using System;
using System.Threading;

namespace  AtomicOperation;

/// <summary>
/// An atomic operation is an operation that is performed indivisibly—it is either fully completed or not done at all,
/// with no intermediate states visible to other threads or processes.
/// This ensures thread safety and data integrity in concurrent programming.
/// </summary>
public static class Program
{
    private static int _counter = 0;

    public static void Main()
    {
        Thread[] threads = new Thread[10];

        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(Increment);
            threads[i].Start();
        }
        
        for (int i = 0; i < 10; i++)
        {
            threads[i].Join();
        }
        
        Console.WriteLine($"Final Counter: {_counter}");
    }
    
    private static void Increment()
    {
        for (int i = 0; i < 50; i++)
        {
            Interlocked.Increment(ref _counter);
        }
    }
}