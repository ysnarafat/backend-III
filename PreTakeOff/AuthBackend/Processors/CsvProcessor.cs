using UserAuthBackend.Models;

namespace UserAuthBackend.Processors
{
    public class CsvProcessor(IUserQueue queue)
    {
        public async Task Process(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 2)
            {
                Console.WriteLine($"Invalid row skipped: {line}");
                return;
            }

            var user = new User(parts[0].Trim(), parts[1].Trim());
            await queue.Enqueue(user);
            Console.WriteLine($"Enqueued {user.Email}");
        }
    }
}
