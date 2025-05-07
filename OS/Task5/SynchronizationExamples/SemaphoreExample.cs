namespace SynchronizationExamples;

/// <summary>
/// Semaphore: Allows a limited number of threads to access a resource concurrently.
/// </summary>
public class SemaphoreExample
{
    private static int sharedResource = 0;
    
    public static void HandleCounter()
    {
        Semaphore semaphore = new Semaphore(3, 4);

        for (int i = 0; i < 10; i++)
        {
            new Thread(() =>
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting for semaphore.");
                semaphore.WaitOne(); // Acquire a semaphore slot
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} acquired semaphore.");

                try
                {
                    // Access limited resource
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} accessing resource.");
                    Thread.Sleep(200); // Simulate resource access
                }
                finally
                {
                    semaphore.Release(); // Release the semaphore slot
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} released semaphore.");
                }
            }).Start();
        }
    }
}