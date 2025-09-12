namespace MediaPlayerSytem
{
    public class AudioFile : IPlayableMedia, ISeekableMedia
    {
        private readonly string _filePath;
        private int _currentPosition = 0;
        private readonly int _duration;

        public AudioFile(string filePath, int duration)
        {
            _filePath = filePath;
            _duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing audio file: {_filePath}");
        public void Pause() => Console.WriteLine($"Pausing audio file: {_filePath}");

        public void Stop()
        {
            _currentPosition = 0;
            Console.WriteLine($"Stopped audio file: {_filePath}");
        }

        public void Resume()
        {
            Console.WriteLine($"Resuming audio: {_filePath} from {_currentPosition}s");
            Play();
        }

        public void FastForward()
        {
            _currentPosition = Math.Min(_currentPosition + 10, _duration);
            Console.WriteLine($"Fast forwarded audio to {_currentPosition}s");
        }

        public void Rewind()
        {
            _currentPosition = Math.Max(_currentPosition - 10, 0);
            Console.WriteLine($"Rewinded audio to {_currentPosition}s");
        }
    }

    public class VideoFile : IPlayableMedia, ISeekableMedia
    {
        private readonly string _filePath;
        private int _currentPosition = 0;
        private readonly int _duration;

        public VideoFile(string filePath, int duration)
        {
            _filePath = filePath;
            _duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing video file: {_filePath}");
        public void Pause() => Console.WriteLine($"Pausing video file: {_filePath}");

        public void Stop()
        {
            _currentPosition = 0;
            Console.WriteLine($"Stopped video file: {_filePath}");
        }

        public void Resume()
        {
            Console.WriteLine($"Resuming video: {_filePath} from {_currentPosition}s");
            Play();
        }

        public void FastForward()
        {
            _currentPosition = Math.Min(_currentPosition + 10, _duration);
            Console.WriteLine($"Fast forwarded video to {_currentPosition}s");
        }

        public void Rewind()
        {
            _currentPosition = Math.Max(_currentPosition - 10, 0);
            Console.WriteLine($"Rewinded video to {_currentPosition}s");
        }
    }

    public class Podcast : IPlayableMedia, ISeekableMedia
    {
        private readonly string _url;
        private int _currentPosition = 0;
        private readonly int _duration;

        public Podcast(string url, int duration)
        {
            _url = url;
            _duration = duration;
        }

        public void Play() => Console.WriteLine($"Playing podcast episode from: {_url}");
        public void Pause() => Console.WriteLine($"Pausing podcast: {_url}");

        public void Stop()
        {
            _currentPosition = 0;
            Console.WriteLine($"Stopped podcast: {_url}");
        }

        public void Resume()
        {
            Console.WriteLine($"Resuming podcast: {_url} from {_currentPosition}s");
            Play();
        }

        public void FastForward()
        {
            _currentPosition = Math.Min(_currentPosition + 10, _duration);
            Console.WriteLine($"Fast forwarded podcast to {_currentPosition}s");
        }

        public void Rewind()
        {
            _currentPosition = Math.Max(_currentPosition - 10, 0);
            Console.WriteLine($"Rewinded podcast to {_currentPosition}s");
        }
    }

    public class LiveStream : IPlayableMedia
    {
        private readonly string _url;
        public LiveStream(string url) => _url = url;

        public void Play() => Console.WriteLine($"Streaming live from: {_url}");
        public void Pause() => Console.WriteLine($"Pausing live stream: {_url}");
        public void Stop() => Console.WriteLine($"Stopped live stream: {_url}");
        public void Resume() => Play();
    }

    public class OnlineRadio : IPlayableMedia
    {
        private readonly string _stationUrl;
        public OnlineRadio(string stationUrl) => _stationUrl = stationUrl;

        public void Play() => Console.WriteLine($"Tuning into radio station: {_stationUrl}");
        public void Pause() => Console.WriteLine($"Pausing radio station: {_stationUrl}");
        public void Stop() => Console.WriteLine($"Stopped radio: {_stationUrl}");
        public void Resume() => Play();
    }

}
