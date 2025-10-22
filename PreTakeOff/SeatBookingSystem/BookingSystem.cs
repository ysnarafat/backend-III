namespace SeatBookingSystem
{
    public class BookingSystem
    {
        private readonly int totalSeats;
        private int availableSeats;
        private readonly object lockObject = new();
        private readonly HashSet<string> bookings = [];
        private int bookingIdCounter = 1;

        public BookingSystem(int totalSeats)
        {
            this.totalSeats = totalSeats;
            this.availableSeats = totalSeats;
        }

        public BookingResult BookSeat(string userName)
        {
            lock (lockObject)
            {
                if (availableSeats <= 0)
                {
                    return new BookingResult
                    {
                        Success = false,
                        Message = "No seats available",
                        UserName = userName
                    };
                }

                availableSeats--;
                string bookingId = $"BK{bookingIdCounter:D5}";
                bookingIdCounter++;

                bookings.Add($"{bookingId}|{userName}");

                return new BookingResult
                {
                    Success = true,
                    Message = $"Seat booked successfully! Booking ID: {bookingId}",
                    UserName = userName,
                    BookingId = bookingId,
                    RemainingSeats = availableSeats
                };
            }
        }

        public bool CancelBooking(string bookingId)
        {
            lock (lockObject)
            {
                var booking = bookings.FirstOrDefault(b => b.StartsWith(bookingId));
                if (booking != null)
                {
                    bookings.Remove(booking);
                    availableSeats++;
                    return true;
                }
                return false;
            }
        }

        public int GetAvailableSeats()
        {
            lock (lockObject)
            {
                return availableSeats;
            }
        }

        public int GetTotalBookings()
        {
            lock (lockObject)
            {
                return bookings.Count;
            }
        }
    }

    public class BookingResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string BookingId { get; set; }
        public int RemainingSeats { get; set; }
    }
}
