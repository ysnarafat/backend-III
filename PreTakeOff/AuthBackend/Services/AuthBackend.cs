using UserAuthBackend.Models;

namespace UserAuthBackend.Services
{
    public class AuthBackend
    {
        public async Task<bool> CreateUser(User user)
        {
            // Simulate delay (auth backend processes one at a time)
            await Task.Delay(500);
            Console.WriteLine($"[AuthBackend] Created {user.Email}");
            return true;
        }
    }
}
