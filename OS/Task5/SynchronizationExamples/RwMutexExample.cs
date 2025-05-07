namespace SynchronizationExamples;

/// <summary>
/// ReaderWriterLockSlim: Allows multiple threads to read a resource concurrently,
/// but only one thread can write at a time. It provides better performance 
/// for scenarios where reads are more frequent than writes.
/// </summary>
public static class RwMutexExample
{
    private static int _sharedResource = 0;
    private static readonly ReaderWriterLockSlim RwLock = new ReaderWriterLockSlim();

    public static void HandleCounter()
    {
        for (int i = 0; i < 3; i++)
        {
            new Thread(() =>
            {
                RwLock.EnterReadLock(); // Acquire read lock
                Console.WriteLine($"Reader {Environment.CurrentManagedThreadId} acquired read lock. sharedResource: {_sharedResource}");
                Thread.Sleep(50); // Simulate reading
                RwLock.ExitReadLock(); // Release read lock
                Console.WriteLine($"Reader {Environment.CurrentManagedThreadId} released read lock.");
            }).Start();
        }

        new Thread(() =>
        {
            RwLock.EnterWriteLock(); // Acquire write lock
            Console.WriteLine($"Writer {Environment.CurrentManagedThreadId} acquired write lock.");
            _sharedResource += 10;
            Thread.Sleep(100); // Simulate writing
            RwLock.ExitWriteLock(); // Release write lock
            Console.WriteLine($"Writer {Environment.CurrentManagedThreadId} released write lock. sharedResource: {_sharedResource}");
        }).Start();
    }
}