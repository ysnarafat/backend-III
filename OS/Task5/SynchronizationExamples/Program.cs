namespace SynchronizationExamples;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Mutex Example:");
        MutexExample.HandleCounter();
        Thread.Sleep(2000); //allow threads to finish before starting next example.
        
        Console.WriteLine("\n\nReaderWriterLockSlim Example:");
        RwMutexExample.HandleCounter();
        Thread.Sleep(2000); //allow threads to finish before starting next example.
        
        Console.WriteLine("\n\nSemaphore Example:");
        SemaphoreExample.HandleCounter();
        Console.ReadKey();
    }
}