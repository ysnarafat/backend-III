using SeatBookingSystem;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Seat Booking System ===");
        Console.WriteLine("Total Seats: 100\n");

        var bookingSystem = new BookingSystem(100);

        // Simulate multiple users trying to book seats concurrently
        Console.WriteLine("Simulating 150 concurrent booking attempts...\n");

        var tasks = new List<Task>();
        var successCount = 0;
        var failCount = 0;
        var lockObj = new object();

        for (int i = 1; i <= 150; i++)
        {
            int userId = i;
            var task = Task.Run(() =>
            {
                var result = bookingSystem.BookSeat($"User{userId}");

                lock (lockObj)
                {
                    if (result.Success)
                    {
                        successCount++;
                        Console.WriteLine($"{result.UserName}: {result.Message} (Remaining: {result.RemainingSeats})");
                    }
                    else
                    {
                        failCount++;
                        Console.WriteLine($"{result.UserName}: {result.Message}");
                    }
                }
            });
            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());

        Console.WriteLine("\n=== Booking Summary ===");
        Console.WriteLine($"Successful Bookings: {successCount}");
        Console.WriteLine($"Failed Bookings: {failCount}");
        Console.WriteLine($"Available Seats: {bookingSystem.GetAvailableSeats()}");
        Console.WriteLine($"Total Bookings in System: {bookingSystem.GetTotalBookings()}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}