namespace SynchronizationExamples;

/// <summary>
/// Mutex: Ensures that only one thread can access a critical section at a time.
/// It is typically used for mutual exclusion across threads or processes.
/// </summary>
public static class MutexExample
{
    private static int _sharedResource = 0;
    private static readonly Mutex Mutex = new Mutex();
    
    public static void HandleCounter()
    {
        for (int i = 0; i < 5; i++)
        {
            var thread = new Thread(IncrementCounter);
            thread.Start();
        }
    }

    private static void IncrementCounter()
    {
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} waiting for mutex.");
        Mutex.WaitOne();
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} acquired mutex.");

        try
        {
            // Critical section: Access shared resource
            _sharedResource++;
            Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} incremented sharedResource to {_sharedResource}.");
            Thread.Sleep(100);
        }
        finally
        {
            Mutex.ReleaseMutex();
            Console.WriteLine($"Thread {Environment.CurrentManagedThreadId} released mutex.");
        }
    }
}