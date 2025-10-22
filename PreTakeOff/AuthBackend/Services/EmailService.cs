using UserAuthBackend.Models;

namespace UserAuthBackend.Services
{
    public class EmailService
    {
        public async Task SendWelcomeEmail(User user)
        {
            await Task.Delay(200);
            Console.WriteLine($"[EmailService] Sent email to {user.Email}");
        }
    }
}
