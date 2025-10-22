using UserAuthBackend.Models;
using UserAuthBackend.Services;

namespace UserAuthBackend.Workers
{
    public class UserWorker : BackgroundService
    {
        private readonly IUserQueue _queue;
        private readonly AuthBackend _authBackend;
        private readonly EmailService _emailService;

        public UserWorker(IUserQueue queue, AuthBackend authBackend, EmailService emailService)
        {
            _queue = queue;
            _authBackend = authBackend;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var user in _queue.DequeueAllAsync(stoppingToken))
            {
                Console.WriteLine($"Processing user: {user.Name}");

                var created = await _authBackend.CreateUser(user);

                if (created)
                {
                    await _emailService.SendWelcomeEmail(user);
                    Console.WriteLine($"User {user.Email} created and email sent");
                }
                else
                {
                    Console.WriteLine($"Failed to create {user.Email}");
                }
            }
        }
    }
}
