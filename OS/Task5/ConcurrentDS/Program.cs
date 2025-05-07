namespace ConcurrentDS;

public class Program
{
     public static void Main(string[] args)
     {
          Console.WriteLine("Concurrent Counter Example:");
          ConcurrentCounter counter = new ConcurrentCounter();
          int incrementsPerThread = 1000;

          for (int i = 0; i < 10; i++)
          {
               new Thread(() =>
               {
                    for (int j = 0; j < incrementsPerThread; j++)
                    {
                         counter.Increment();
                    }
               }).Start();
          }
          
          Console.WriteLine($"Final count: {counter.GetCount()}");
          Console.ReadKey();
     }
}