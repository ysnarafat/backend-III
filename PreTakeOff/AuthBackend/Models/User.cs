using System.Threading.Channels;

namespace UserAuthBackend.Models
{
    public record User(string Name, string Email);

    public interface IUserQueue
    {
        ValueTask Enqueue(User user);
        IAsyncEnumerable<User> DequeueAllAsync(CancellationToken ct);
    }

    public class UserQueue : IUserQueue
    {
        private readonly Channel<User> _channel = Channel.CreateUnbounded<User>();

        public async ValueTask Enqueue(User user) =>
            await _channel.Writer.WriteAsync(user);

        public IAsyncEnumerable<User> DequeueAllAsync(CancellationToken ct) =>
            _channel.Reader.ReadAllAsync(ct);
    }
}
